using Microsoft.Extensions.DependencyInjection;

namespace SavingGoals.SI {
    public class StartupDependencyInjection {

        IServiceCollection services;

        public StartupDependencyInjection(IServiceCollection services) {
            this.services = services;
        }

        public void InjectDependencies() {

        }
    }
}
