namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

public record AssignUserResource(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    string StartDate,
    string Plant,
    string Role,
    string Permission
);