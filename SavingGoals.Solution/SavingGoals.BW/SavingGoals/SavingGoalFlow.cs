using System.Collections.Generic;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingGoals.Contracts;

namespace SavingGoals.BW.SavingGoals {
    public class SavingGoalFlow : ISavingGoalFlow {

        private readonly ISavingGoalDataAccess savingGoalDataAccess;

        public SavingGoalFlow(ISavingGoalDataAccess savingGoalDataAccess) {
            this.savingGoalDataAccess = savingGoalDataAccess;
        }

        public List<SavingGoal> GetSavingGoals() {
            List<SavingGoal> savingGoals;

            savingGoals = savingGoalDataAccess.GetSavingGoals();

            return savingGoals;
        }

        public SavingGoal GetSavingGoal(int idSavingGoal) {
            SavingGoal savingGoal;

            //Validate id
            savingGoal = savingGoalDataAccess.GetSavingGoal(idSavingGoal);

            return savingGoal;
        }

        public void AddSavingGoal(SavingGoal savingGoal) {
            //Validate object
            savingGoalDataAccess.AddSavingGoal(savingGoal);
        }

        public void UpdateSavingGoal(SavingGoal savingGoal) {
            //Validate object
            savingGoalDataAccess.UpdateSavingGoal(savingGoal);
        }

        public void DeleteSavingGoal(int idSavingGoal) {
            //Validate id
            savingGoalDataAccess.DeleteSavingGoal(idSavingGoal);
        }
    }
}
