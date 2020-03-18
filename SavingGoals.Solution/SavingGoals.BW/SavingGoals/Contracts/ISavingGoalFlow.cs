using SavingGoals.BC.SavingGoals.Models;
using System.Collections.Generic;

namespace SavingGoals.BW.SavingGoals.Contracts {
    public interface ISavingGoalFlow {

        List<SavingGoal> GetSavingGoals();

        Response GetSavingGoal(int idSavingGoal);

        Response AddSavingGoal(SavingGoal savingGoal);

        Response UpdateSavingGoal(SavingGoal savingGoal);

        Response DeleteSavingGoal(int idSavingGoal);

    }
}
