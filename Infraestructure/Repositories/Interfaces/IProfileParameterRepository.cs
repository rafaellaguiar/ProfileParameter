using Projeto.Models;

namespace Infraestructure.Repositories.Interfaces
{
    public interface IProfileParameterRepository
    {
        List<ProfileParameter> ListProfiles();
        ProfileParameter? GetProfileParametersByName(string name);
        void AddProfileParameter(ProfileParameter profileParameter);
        void UpdateProfileParameter(ProfileParameter newProfileParameter);
        bool DeleteProfileParameter(ProfileParameter profileParameter);
    }
}
