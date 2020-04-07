using Microsoft.AspNetCore.Mvc;
using SavingGoals.BC.SavingCalculation.Models;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingCalculation;
using SavingGoals.BW.SavingGoals;
using SavingGoals.BW.SavingGoals.Contracts;

namespace SavingGoals.SI.Controllers.SavingGoals
{
    [Route("api/savingCalculation")]
    [ApiController]
    public class SavingCalculationController : ControllerBase {

        [HttpGet]
        public CalculationResponse GetCurrentAndFutureTransactions([FromServices] ISavingGoalDataAccess savingGoalDataAccess, 
                                                                   [FromQuery] int idSavingGoal, [FromQuery] decimal estimatedAmount,
                                                                   [FromQuery] decimal savingPerMonth) {

            CalculationResponse calculationResponse = new CalculationResponse();
            Response response;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            response = savingGoalFlow.GetSavingGoal(idSavingGoal);

            if (response.ErrorFound.IsThereAnyError) {
                calculationResponse.ErrorFound = response.ErrorFound;

                return calculationResponse;
            }

            SavingCalculationFlow savingCalculationFlow = new SavingCalculationFlow();
            calculationResponse = 
                savingCalculationFlow.GetCurrentAndFutureTransactions(response.SavingGoal, estimatedAmount, savingPerMonth);

            return calculationResponse;
        }
    }
}