using System.Collections.Generic;
using SavingGoals.BC.SavingGoals;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingGoals.Contracts;

namespace SavingGoals.BW.SavingGoals {
    public class SavingGoalFlow : ISavingGoalFlow {

        private readonly ISavingGoalDataAccess savingGoalDataAccess;
        private readonly SavingGoalValidator savingGoalValidator;

        public SavingGoalFlow(ISavingGoalDataAccess savingGoalDataAccess) {
            this.savingGoalDataAccess = savingGoalDataAccess;
            savingGoalValidator = new SavingGoalValidator();
        }

        public List<SavingGoal> GetSavingGoals() {
            List<SavingGoal> savingGoals;

            savingGoals = savingGoalDataAccess.GetSavingGoals();

            return savingGoals;
        }

        public Response GetSavingGoal(int idSavingGoal) {
            Response response = new Response {
                ErrorFound = savingGoalValidator.ValidateSavingGoalId(idSavingGoal)
            };

            if (!response.ErrorFound.IsThereAnyError) {
                response.SavingGoal = savingGoalDataAccess.GetSavingGoal(idSavingGoal);
            }

            return response;
        }

        public Response AddSavingGoal(SavingGoal savingGoal) {
            Response response = new Response {
                ErrorFound = savingGoalValidator.ValidateSavingGoal(savingGoal)
            };

            if (!response.ErrorFound.IsThereAnyError) {
                savingGoalDataAccess.AddSavingGoal(savingGoal);
            }

            return response;
        }

        public Response UpdateSavingGoal(SavingGoal savingGoal) {
            Response response = new Response {
                ErrorFound = savingGoalValidator.ValidateSavingGoal(savingGoal)
            };

            if (!response.ErrorFound.IsThereAnyError) {
                savingGoalDataAccess.UpdateSavingGoal(savingGoal);
            }

            return response;
        }

        public Response DeleteSavingGoal(int idSavingGoal) {
            Response response = new Response {
                ErrorFound = savingGoalValidator.ValidateSavingGoalId(idSavingGoal)
            };

            if (!response.ErrorFound.IsThereAnyError) {
                savingGoalDataAccess.DeleteSavingGoal(idSavingGoal);
            }

            return response;
        }
    }
}
