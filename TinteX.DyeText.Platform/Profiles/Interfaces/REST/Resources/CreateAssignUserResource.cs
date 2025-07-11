namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

public record CreateAssignUserResource(
    string Name,
    string Email,
    string Phone,
    DateTime StartDate,
    string Plant,
    string Role,
    string Permission
);