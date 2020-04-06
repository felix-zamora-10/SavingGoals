using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SavingGoals.DA.SavingGoals;

namespace SavingGoals.SI {
    public class Startup {
        public Startup(IHostingEnvironment environment) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            ConfigureDatabase(services);
            ConfigureCrossPlatform(services);
            AddDependencyInjection(services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        private void ConfigureDatabase(IServiceCollection services) {
            var connectionString = Configuration.GetConnectionString("SavingGoalsDBDev");
            services.AddDbContext<SavingGoalContext>(opciones => opciones.UseSqlServer(connectionString));
        }

        private static void ConfigureCrossPlatform(IServiceCollection services) {
            services.AddCors(builder => builder
            .AddPolicy("CORS_SECURITY_CONFIGURATION",
            policyBuilder => policyBuilder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()));
        }

        private static void AddDependencyInjection(IServiceCollection services) {
            var dependencyInjection = new StartupDependencyInjection(services);
            dependencyInjection.InjectDependencies();
        }
    }
}
