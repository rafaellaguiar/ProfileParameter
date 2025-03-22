namespace Projeto.Models
{
    public class ProfileParameter(string profileName, Dictionary<string, bool> parameters)
    {
        public string ProfileName { get; private set; } = profileName;
        public Dictionary<string, bool> Parameters { get; private set; } = parameters;

        public void SetParameters(Dictionary<string, bool> parameters)
            => Parameters = parameters;
    }
}
