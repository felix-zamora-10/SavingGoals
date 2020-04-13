using System.Collections.Generic;

namespace SavingGoals.BC.SavingGoals.Models {
    public class SavingGoal {

        public int IdSavingGoal { get; set; }

        public string Description { get; set; }

        public List<MonthlyMovement> MonthlyMovements { get; set; }
    }
}
