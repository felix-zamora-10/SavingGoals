using Microsoft.Extensions.DependencyInjection;
using SavingGoals.BW.SavingGoals;
using SavingGoals.BW.SavingGoals.Contracts;
using SavingGoals.DA.SavingGoals;

namespace SavingGoals.SI {
    public class StartupDependencyInjection {

        IServiceCollection services;

        public StartupDependencyInjection(IServiceCollection services) {
            this.services = services;
        }

        public void InjectDependencies() {
            services.AddTransient<ISavingGoalDataAccess, SavingGoalDataAccess>();
            services.AddTransient<ISavingGoalFlow, SavingGoalFlow>();
        }
    }
}
