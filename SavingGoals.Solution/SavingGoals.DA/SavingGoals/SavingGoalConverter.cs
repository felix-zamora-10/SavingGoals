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
                    AmountSaved = savingGoalToConvert.AmountSaved
                });
            }

            return savingGoalsConverted;
        }

        public SavingGoal ConvertSavingGoal(SavingGoalTable savingGoalToConvert) {
            SavingGoal savingGoalConverted = new SavingGoal {
                IdSavingGoal = savingGoalToConvert.IdSavingGoal,
                Description = savingGoalToConvert.Description,
                AmountSaved = savingGoalToConvert.AmountSaved
            };

            return savingGoalConverted;
        }
    }
}