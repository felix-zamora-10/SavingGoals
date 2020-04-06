using System;
using System.Collections.Generic;
using System.Linq;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BC.Utilities;
using SavingGoals.BW.SavingGoals.Contracts;
using SavingGoals.DA.Tables;

namespace SavingGoals.DA.SavingGoals {
    public class SavingGoalDataAccess : ISavingGoalDataAccess {

        private readonly SavingGoalContext savingGoalContext;
        private readonly SavingGoalConverter savingGoalConverter;

        public SavingGoalDataAccess(SavingGoalContext savingGoalContext) {
            this.savingGoalContext = savingGoalContext;
            savingGoalConverter = new SavingGoalConverter();
        }

        public List<SavingGoal> GetSavingGoals() {
            List<SavingGoalTable> savingGoals;
            List<SavingGoal> savingGoalsConverted;

            savingGoals = savingGoalContext.SavingGoal.ToList();
            savingGoalsConverted = savingGoalConverter.ConvertAllSavingGoals(savingGoals);
            
            return savingGoalsConverted;
        }

        public SavingGoal GetSavingGoal(int idSavingGoal) {
            SavingGoalTable savingGoalEntity;
            SavingGoal savingGoalConverted;

            savingGoalEntity = savingGoalContext.SavingGoal.Where(
                savingGoal => savingGoal.IdSavingGoal == idSavingGoal).FirstOrDefault<SavingGoalTable>();
            savingGoalConverted = savingGoalConverter.ConvertSavingGoal(savingGoalEntity);
            
            return savingGoalConverted;
        }

        public void AddSavingGoal(SavingGoal savingGoal) {
            try {
                SavingGoalTable savingGoalTable = new SavingGoalTable {
                    Description = savingGoal.Description,
                    InitialAmount = savingGoal.InitialAmount
                };

                savingGoalContext.SavingGoal.Add(savingGoalTable);
                savingGoalContext.SaveChanges();
            } catch (Exception exception) {
                throw new SavingGoalException(exception.Message);
            }
        }

        public void UpdateSavingGoal(SavingGoal savingGoal) {
            try {
                SavingGoalTable savingGoalTable;

                savingGoalTable = savingGoalContext.SavingGoal.FirstOrDefault(item => item.IdSavingGoal == savingGoal.IdSavingGoal);

                if (savingGoalTable != null) {
                    savingGoalTable.Description = savingGoal.Description;
                    savingGoalTable.InitialAmount = savingGoal.InitialAmount;

                    savingGoalContext.SavingGoal.Update(savingGoalTable);
                    savingGoalContext.SaveChanges();
                }
            } catch (Exception exception) {
                throw new SavingGoalException(exception.Message);
            }
        }

        public void DeleteSavingGoal(int idSavingGoal) {
            try {
                SavingGoalTable savingGoalTable;

                savingGoalTable = savingGoalContext.SavingGoal.FirstOrDefault(item => item.IdSavingGoal == idSavingGoal);

                if (savingGoalTable != null) {
                    savingGoalContext.SavingGoal.Remove(savingGoalTable);
                    savingGoalContext.SaveChanges();
                }
            } catch (Exception exception) {
                throw new SavingGoalException(exception.Message);
            }
        }
    }
}
