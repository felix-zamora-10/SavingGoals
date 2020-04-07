using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BC.Utilities;
using SavingGoals.BC.Utilities.Models;
using System.Collections.Generic;

namespace SavingGoals.BC.SavingCalculation {
    public class SavingValidator {

        private const int ID_ALLOWED = 1;
        private const decimal AMOUNT_ALLOWED = 1;

        public ErrorFound ValidateSavingCalculation(SavingGoal savingGoal, decimal estimatedAmount, decimal savingPerMonth) {
            ErrorFound errors = new ErrorFound();

            ValidateSavingGoalNull(savingGoal, errors);
            ValidateMonthlyMovementsNull(savingGoal.MonthlyMovements, errors);
            ValidateAmount(estimatedAmount, errors);
            ValidateSavingPerMonth(savingPerMonth, errors);

            return errors;
        }

        public ErrorFound ValidateEstimatedAmount(decimal estimatedAmount, decimal totalAmount) {
            ErrorFound errors = new ErrorFound();

            if (estimatedAmount <= totalAmount) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_TargetAmountError"));
            }

            return errors;
        }

        private void ValidateSavingGoalId(int idSavingGoal, ErrorFound errors) {
            if (idSavingGoal < ID_ALLOWED) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_IdError"));
            }
        }

        private void ValidateAmount(decimal estimatedAmount, ErrorFound errors) {
            if (estimatedAmount < AMOUNT_ALLOWED) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_EstimatedAmountError"));
            }
        }

        private void ValidateSavingPerMonth(decimal savingPerMonth, ErrorFound errors) {
            if (savingPerMonth < AMOUNT_ALLOWED) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_SavingPerMonthError"));
            }
        }

        private void ValidateSavingGoalNull(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal is null) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_SavingGoalNull"));
            }
        }

        private void ValidateMonthlyMovementsNull(List<MonthlyMovement> monthlyMovements, ErrorFound errors) {
            if (monthlyMovements is null) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingCalculation_MonthlyMovementsNull"));
            }
        }
    }
}
