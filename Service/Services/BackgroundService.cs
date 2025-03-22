using Infraestructure.Repositories.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Projeto.Services
{
    public class BackgroundService(IProfileParameterRepository profileParameterRepository) : IHostedService, IDisposable
    {
        private Timer? timer = null;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(UpdateParameters, null , TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void UpdateParameters(object? state)
        {
            var listParameters = profileParameterRepository.ListProfiles();

            foreach(var profileParameter in listParameters)
            {
                var keys = profileParameter.Parameters.Keys;

                foreach(var key in keys)
                    profileParameter.Parameters[key] = !profileParameter.Parameters[key];

                profileParameterRepository.UpdateProfileParameter(profileParameter);
            }
        }

        public void Dispose() => timer?.Dispose();

    }
}
