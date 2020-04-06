using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavingGoals.DA.Tables {
    [Table("SGMonthlyMovement")]
    public class MonthlyMovementTable {

        [Key]
        public int IdMonthlyMovement { get; set; }

        [ForeignKey("SGSavingGoal")]
        public int IdSavingGoal { get; set; }

        public short Year { get; set; }

        public byte Month { get; set; }

        public decimal SavedAmount { get; set; }
    }
}
