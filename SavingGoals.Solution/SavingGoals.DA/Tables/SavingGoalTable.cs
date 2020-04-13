using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavingGoals.DA.Tables {
    [Table("SGSavingGoal")]
    public class SavingGoalTable {

        [Key]
        public int IdSavingGoal { get; set; }

        public string Description { get; set; }

        public List<MonthlyMovementTable> MonthlyMovements { get; set; }
    }
}
