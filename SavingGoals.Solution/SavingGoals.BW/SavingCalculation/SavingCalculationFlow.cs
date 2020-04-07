using SavingGoals.BC.SavingCalculation;
using SavingGoals.BC.SavingCalculation.Models;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingCalculation.Contracts;

namespace SavingGoals.BW.SavingCalculation {
    public class SavingCalculationFlow : ISavingCalculationFlow {

        private readonly SavingValidator savingValidator;
        private readonly SavingCalculator savingCalculator;

        public SavingCalculationFlow() {
            savingValidator = new SavingValidator();
            savingCalculator = new SavingCalculator();
        }

        public CalculationResponse GetCurrentAndFutureTransactions(SavingGoal savingGoal, decimal estimatedAmount, decimal savingPerMonth) {
            decimal totalAmount;
            CalculationResponse calculationResponse = new CalculationResponse {
                ErrorFound = savingValidator.ValidateSavingCalculation(savingGoal, estimatedAmount, savingPerMonth)
            };

            if (calculationResponse.ErrorFound.IsThereAnyError) {
                return calculationResponse;
            }

            totalAmount = savingCalculator.GetTotalAmount(savingGoal);
            calculationResponse.ErrorFound = savingValidator.ValidateEstimatedAmount(estimatedAmount, totalAmount);

            if (calculationResponse.ErrorFound.IsThereAnyError) {
                return calculationResponse;
            }

            calculationResponse.Periods = savingCalculator.CreateCurrentAndFutureTransactions(savingGoal.MonthlyMovements, 
                                                totalAmount, estimatedAmount, savingPerMonth);

            return calculationResponse;
        }
    }
}
