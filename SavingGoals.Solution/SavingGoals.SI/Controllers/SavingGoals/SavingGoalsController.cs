using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SavingGoals.BC.SavingGoals.Models;
using SavingGoals.BW.SavingGoals;
using SavingGoals.BW.SavingGoals.Contracts;

namespace SavingGoals.SI.Controllers {
    [Route("api/savingGoals")]
    [ApiController]
    public class SavingGoalsController : ControllerBase {

        // GET api/savingGoals
        [HttpGet]
        public List<SavingGoal> GetAllSavingGoals([FromServices] ISavingGoalDataAccess savingGoalDataAccess) {
            List<SavingGoal> savingGoals;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            savingGoals = savingGoalFlow.GetSavingGoals();

            return savingGoals;
        }

        // GET api/savingGoals/5
        [HttpGet("{id}")]
        public Response GetSavingGoal([FromServices] ISavingGoalDataAccess savingGoalDataAccess, [FromQuery] int idSavingGoal) {
            Response response;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            response = savingGoalFlow.GetSavingGoal(idSavingGoal);

            return response;
        }

        // POST api/savingGoals
        [HttpPost]
        public Response AddSavingGoal([FromServices] ISavingGoalDataAccess savingGoalDataAccess, [FromQuery] SavingGoal savingGoal) {
            Response response;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            response = savingGoalFlow.AddSavingGoal(savingGoal);

            return response;
        }

        // PUT api/savingGoals/5
        [HttpPut("{id}")]
        public Response UpdateSavingGoal([FromServices] ISavingGoalDataAccess savingGoalDataAccess, [FromQuery] SavingGoal savingGoal) {
            Response response;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            response = savingGoalFlow.UpdateSavingGoal(savingGoal);

            return response;
        }

        // DELETE api/savingGoals/5
        [HttpDelete("{id}")]
        public Response DeleteSavingGoal([FromServices] ISavingGoalDataAccess savingGoalDataAccess, [FromQuery] int idSavingGoal) {
            Response response;

            SavingGoalFlow savingGoalFlow = new SavingGoalFlow(savingGoalDataAccess);
            response = savingGoalFlow.DeleteSavingGoal(idSavingGoal);

            return response;
        }
    }
}
