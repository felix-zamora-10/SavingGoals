namespace SavingGoals.BC.SavingGoals.Models {
    public class MonthlyMovement {
        public int IdMonthlyMovement { get; set; }

        public int IdSavingGoal { get; set; }

        public short Year { get; set; }

        public byte Month { get; set; }

        public decimal SavedAmount { get; set; }
    }
}
