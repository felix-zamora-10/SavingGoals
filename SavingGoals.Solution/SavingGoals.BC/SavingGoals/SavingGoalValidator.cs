using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BC.Utilities;
using SavingGoals.BC.Utilities.Models;

namespace SavingGoals.BC.SavingGoals {
    public class SavingGoalValidator {

        private const int ID_ALLOWED = 1;

        public ErrorFound ValidateSavingGoalId(int id) {
            ErrorFound errors = new ErrorFound();

            if (id < ID_ALLOWED) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_IdError"));
            }

            return errors;
        }

        public ErrorFound ValidateSavingGoal(SavingGoal savingGoal) {
            ErrorFound errors = new ErrorFound();

            ValidateSavingGoalNull(savingGoal, errors);
            ValidateSavingGoalDescription(savingGoal, errors);
            ValidateSavingGoalAmountSaved(savingGoal, errors);

            return errors;
        }

        private void ValidateSavingGoalNull(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal == null) {
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

        private void ValidateSavingGoalAmountSaved(SavingGoal savingGoal, ErrorFound errors) {
            if (savingGoal.InitialAmount < 0) {
                errors.IsThereAnyError = true;
                errors.ErrorsFound.Add(Messages.ResourceManager.GetString("SavingGoal_AmountSavedError"));
            }
        }
    }
}
