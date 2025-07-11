namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

public record UpdateProfileResource(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    bool MembershipActive,
    string Theme
);