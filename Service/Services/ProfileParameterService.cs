using Infraestructure.Repositories.Interfaces;
using Projeto.Models;
using Service.Services.Interfaces;

namespace Projeto.Services
{
    public class ProfileParameterService(IProfileParameterRepository profileParameterRepository) : IProfileParameterService
    {
        public List<ProfileParameter> ListProfiles() => profileParameterRepository.ListProfiles();

        public ProfileParameter GetProfile(string name)
        {
            return profileParameterRepository.GetProfileParametersByName(name) ?? throw new ArgumentException("Não existe um perfil com este nome"); ;
        }

        public bool AddProfile(ProfileParameter newProfileParameter)
        {
            var profileParameter = profileParameterRepository.GetProfileParametersByName(newProfileParameter.ProfileName);

            if (profileParameter is not null)
                throw new ArgumentException("Já existe um perfil com esse nome");

            profileParameterRepository.AddProfileParameter(newProfileParameter);

            return true;
        } 
        public bool UpdateProfile(string profilename, Dictionary<string, bool> parameter)
        {
            var profileParameter = profileParameterRepository.GetProfileParametersByName(profilename) ?? throw new ArgumentException("Não existe um perfil com este nome");
            profileParameter.SetParameters(parameter);

            profileParameterRepository.UpdateProfileParameter(profileParameter);

            return true;
        }

        public bool DeleteProfile(string profilename)
        {
            var profileParameter = profileParameterRepository.GetProfileParametersByName(profilename) ?? throw new ArgumentException("Não existe um perfil com este nome"); ;

            return profileParameterRepository.DeleteProfileParameter(profileParameter);
        }

        public string ValidatePerfil(string profileName, string parameterName)
        {
            var profileParameter = profileParameterRepository.GetProfileParametersByName(profileName) ?? throw new ArgumentException("Não existe um perfil com este nome");

            var isValid = profileParameter.Parameters[parameterName] ? "possui" : "não possui";

            return $"O perfil {profileName} {isValid} permissao para a ação {parameterName}";
        }
    }
}
