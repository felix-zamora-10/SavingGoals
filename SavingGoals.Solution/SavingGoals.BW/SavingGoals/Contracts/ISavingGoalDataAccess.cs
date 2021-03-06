﻿using SavingGoals.BC.SavingGoals.Models;
using System.Collections.Generic;

namespace SavingGoals.BW.SavingGoals.Contracts {
    public interface ISavingGoalDataAccess {

        List<SavingGoal> GetSavingGoals();

        SavingGoal GetSavingGoal(int idSavingGoal);

        void AddSavingGoal(SavingGoal savingGoal);

        void UpdateSavingGoal(SavingGoal savingGoal);

        void DeleteSavingGoal(int idSavingGoal);

    }
}
