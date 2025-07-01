namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;


public record ProfileResource(
    int Id,
    string FullName,
    string Email,
    string Phone,
    bool MembershipActive,
    string Theme
);
