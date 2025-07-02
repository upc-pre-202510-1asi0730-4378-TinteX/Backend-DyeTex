namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

public record CreateProfileResource(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    bool MembershipActive,
    string Theme
);