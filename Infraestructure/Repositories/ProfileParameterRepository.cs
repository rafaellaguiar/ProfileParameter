using Infraestructure.Repositories.Interfaces;
using Projeto.Models;

namespace Infraestructure.Repositories
{
    public class ProfileParameterRepository : IProfileParameterRepository
    {
        private readonly List<ProfileParameter> profiles = new();
        private static readonly object _lock = new();

        public List<ProfileParameter> ListProfiles() => profiles.ToList();

        public ProfileParameter? GetProfileParametersByName(string name) =>
            profiles.FirstOrDefault(x => x.ProfileName.Equals(name));

        public void AddProfileParameter(ProfileParameter profileParameter)
        {
            lock (_lock)
            {
                profiles.Add(profileParameter);
            }
        }

        public void UpdateProfileParameter(ProfileParameter newProfileParameter)
        {
            var profile = profiles.FirstOrDefault(x => x.ProfileName.Equals(newProfileParameter.ProfileName));

            lock (_lock)
            {
                profile.SetParameters(newProfileParameter.Parameters);
            }
        }

        public bool DeleteProfileParameter(ProfileParameter profileParameter)
        {
            lock (_lock)
            {
                return profiles.Remove(profileParameter);
            }
        }
    }
}
