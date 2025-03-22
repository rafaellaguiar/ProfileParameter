using Projeto.Models;

namespace Service.Services.Interfaces
{
    public interface IProfileParameterService
    {
        List<ProfileParameter> ListProfiles();
        ProfileParameter GetProfile(string name);
        bool AddProfile(ProfileParameter newProfileParameter);
        bool UpdateProfile(string profilename, Dictionary<string, bool> parameter);
        bool DeleteProfile(string profilename);
        string ValidatePerfil(string profileName, string parameterName);
    }
}
