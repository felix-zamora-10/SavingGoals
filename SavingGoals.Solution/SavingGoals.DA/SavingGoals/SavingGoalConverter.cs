using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.DA.Tables;
using System.Collections.Generic;

namespace SavingGoals.DA.SavingGoals {
    class SavingGoalConverter {

        public List<SavingGoal> ConvertAllSavingGoals(List<SavingGoalTable> savingGoalsToConvert) {
            List<SavingGoal> savingGoalsConverted = new List<SavingGoal>();

            foreach (SavingGoalTable savingGoalToConvert in savingGoalsToConvert) {
                savingGoalsConverted.Add(new SavingGoal {
                    IdSavingGoal = savingGoalToConvert.IdSavingGoal,
                    Description = savingGoalToConvert.Description,
                    InitialAmount = savingGoalToConvert.InitialAmount,
                    MonthlyMovements = ConvertMonthlyMovements(savingGoalToConvert.MonthlyMovements)
                });
            }

            return savingGoalsConverted;
        }

        public SavingGoal ConvertSavingGoal(SavingGoalTable savingGoalToConvert) {
            SavingGoal savingGoalConverted = new SavingGoal {
                IdSavingGoal = savingGoalToConvert.IdSavingGoal,
                Description = savingGoalToConvert.Description,
                InitialAmount = savingGoalToConvert.InitialAmount,
                MonthlyMovements = ConvertMonthlyMovements(savingGoalToConvert.MonthlyMovements)
            };

            return savingGoalConverted;
        }

        public List<MonthlyMovement> ConvertMonthlyMovements(List<MonthlyMovementTable> monthlyMovementsToConvert) {
            List<MonthlyMovement> monthlyMovementsConverted = new List<MonthlyMovement>();

            foreach (MonthlyMovementTable monthlyMovementToConvert in monthlyMovementsToConvert) {
                monthlyMovementsConverted.Add(new MonthlyMovement {
                    IdMonthlyMovement = monthlyMovementToConvert.IdMonthlyMovement,
                    IdSavingGoal = monthlyMovementToConvert.IdSavingGoal,
                    Year = monthlyMovementToConvert.Year,
                    Month = monthlyMovementToConvert.Month,
                    SavedAmount = monthlyMovementToConvert.SavedAmount
                });
            }

            return monthlyMovementsConverted;
        }

        public List<MonthlyMovementTable> ConvertMonthlyMovementsTable(List<MonthlyMovement> monthlyMovementsToConvert) {
            List<MonthlyMovementTable> monthlyMovementsConverted = new List<MonthlyMovementTable>();

            foreach (MonthlyMovement monthlyMovementToConvert in monthlyMovementsToConvert) {
                monthlyMovementsConverted.Add(new MonthlyMovementTable {
                    IdMonthlyMovement = monthlyMovementToConvert.IdMonthlyMovement,
                    IdSavingGoal = monthlyMovementToConvert.IdSavingGoal,
                    Year = monthlyMovementToConvert.Year,
                    Month = monthlyMovementToConvert.Month,
                    SavedAmount = monthlyMovementToConvert.SavedAmount
                });
            }

            return monthlyMovementsConverted;
        }
    }
}