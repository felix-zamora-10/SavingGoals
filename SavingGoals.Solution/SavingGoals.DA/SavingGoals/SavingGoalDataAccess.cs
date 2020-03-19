using System;
using System.Collections.Generic;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingGoals.Contracts;
using SavingGoals.DA.Tables;

namespace SavingGoals.DA.SavingGoals {
    public class SavingGoalDataAccess : ISavingGoalDataAccess {

        private SavingGoalContext savingGoalContext;

        public SavingGoalDataAccess(SavingGoalContext savingGoalContext) {
            this.savingGoalContext = savingGoalContext;
        }

        public List<SavingGoal> GetSavingGoals() {
            throw new System.NotImplementedException();
        }

        public SavingGoal GetSavingGoal(int idSavingGoal) {
            throw new System.NotImplementedException();
        }

        public void AddSavingGoal(SavingGoal savingGoal) {
            try {
                SavingGoalTable savingGoalTable = new SavingGoalTable {
                    Description = savingGoal.Description,
                    AmountSaved = savingGoal.AmountSaved
                };

                savingGoalContext.SavingGoal.Add(savingGoalTable);
                savingGoalContext.SaveChanges();
            } catch (Exception exception) {
                throw new Exception(exception.Message);
            }
        }

        public void UpdateSavingGoal(SavingGoal savingGoal) {
            throw new System.NotImplementedException();
        }

        public void DeleteSavingGoal(int idSavingGoal) {
            throw new System.NotImplementedException();
        }
    }
}
