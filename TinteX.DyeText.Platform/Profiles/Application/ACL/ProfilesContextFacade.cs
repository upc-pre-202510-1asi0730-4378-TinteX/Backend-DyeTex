using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Domain.Model.Queries;
using TinteX.DyeText.Platform.Profiles.Domain.Model.ValueObjects;
using TinteX.DyeText.Platform.Profiles.Domain.Services;
using TinteX.DyeText.Platform.Profiles.Interfaces.ACL;

namespace TinteX.DyeText.Platform.Profiles.Application.ACL;

/// <summary>
/// Facade for the profiles context 
/// </summary>
public class ProfilesContextFacade(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService
) : IProfilesContextFacade
{
    public async Task<int> CreateProfile(
        string firstName,
        string lastName,
        string email,
        string phone,
        bool membershipActive,
        string theme)
    {
        var createProfileCommand = new CreateProfileCommand(
            firstName,
            lastName,
            email,
            phone,
            membershipActive,
            theme
        );
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }

    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}