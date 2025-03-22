using Infraestructure.Repositories;
using Infraestructure.Repositories.Interfaces;
using Projeto.Services;
using Service.Services.Interfaces;
using BackgroundService = Projeto.Services.BackgroundService;

namespace Projeto.Configuration
{
    public static class AppModule
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddHostedService<BackgroundService>();
            services.AddTransient<IProfileParameterService, ProfileParameterService>();
            services.AddSingleton<IProfileParameterRepository, ProfileParameterRepository>();
        }
    }
}
