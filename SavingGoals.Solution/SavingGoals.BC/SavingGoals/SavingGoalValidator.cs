using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BC.Utilities;
using SavingGoals.BC.Utilities.Models;
using System.Collections.Generic;

namespace SavingGoals.BC.SavingGoals {
    public class SavingGoalValidator {

        private const int ID_ALLOWED = 1;

        public ErrorFound ValidateSavingGoalId(int idSavingGoal) {
            ErrorFound errors = new ErrorFound();

            if (idSavingGoal < ID_ALLOWED) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_IdError"));
            }

            return errors;
        }

        public ErrorFound ValidateSavingGoal(SavingGoal savingGoal) {
            ErrorFound errors = new ErrorFound();

            ValidateSavingGoalNull(savingGoal, errors);
            if (errors.IsThereAnyError) return errors;
            ValidateSavingGoalDescription(savingGoal, errors);
            ValidateMonthlyMovementsNull(savingGoal.MonthlyMovements, errors);
            if (errors.IsThereAnyError) return errors;
            ValidateMonthlyMovements(savingGoal.MonthlyMovements, errors);
            ValidateSavingGoalAmountSaved(savingGoal, errors);

            return errors;
        }

        private void ValidateSavingGoalNull(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal is null) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_NullObject"));
            }
        }

        private void ValidateSavingGoalDescription(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal.Description == string.Empty) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_DescriptionError"));
            }
        }

        private void ValidateMonthlyMovementsNull(List<MonthlyMovement> monthlyMovements, ErrorFound errors) {
            if (monthlyMovements is null) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_MonthlyMovementsNull"));
            }
        }

        private void ValidateMonthlyMovements(List<MonthlyMovement> monthlyMovements, ErrorFound errors) {
            if (monthlyMovements.Count > 0) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_MonthlyMovements"));
            }
        }

        private void ValidateSavingGoalAmountSaved(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal.MonthlyMovements[0].SavedAmount < decimal.Zero) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_AmountSavedError"));
            }
        }
    }
}
