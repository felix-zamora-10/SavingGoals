using Microsoft.EntityFrameworkCore;
using SavingGoals.DA.Tables;

namespace SavingGoals.DA.SavingGoals {
    public class SavingGoalContext : DbContext {

        public SavingGoalContext(DbContextOptions<SavingGoalContext> options) : base(options) {

        }

        public DbSet<SavingGoalTable> SavingGoal { get; set; }
    }
}
