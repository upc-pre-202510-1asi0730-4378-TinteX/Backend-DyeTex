using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

public static class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommand(UpdateProfileResource r)
        => new UpdateProfileCommand(
            r.Id,
            r.FirstName,
            r.LastName,
            r.Email,
            r.Phone,
            r.MembershipActive,
            r.Theme
        );
}