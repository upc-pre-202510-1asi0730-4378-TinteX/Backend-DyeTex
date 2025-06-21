namespace TinteX.DyeText.Platform.Profiles.Interfaces.ACL;

/// <summary>
/// Facade for the profiles context 
/// </summary>

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email);
    Task<int> FetchProfileIdByEmail(string email);
}
