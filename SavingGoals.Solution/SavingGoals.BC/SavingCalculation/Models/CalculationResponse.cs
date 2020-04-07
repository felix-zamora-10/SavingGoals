using SavingGoals.BC.Utilities.Models;
using System.Collections.Generic;

namespace SavingGoals.BC.SavingCalculation.Models {
    public class CalculationResponse {

        public ErrorFound ErrorFound { get; set; }

        public List<Period> Periods { get; set; }
    }
}
