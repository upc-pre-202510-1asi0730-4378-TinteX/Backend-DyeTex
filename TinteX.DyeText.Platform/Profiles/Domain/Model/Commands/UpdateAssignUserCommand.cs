// TinteX.DyeText.Platform/Profiles/Domain/Model/Commands/UpdateAssignUserCommand.cs
namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

public record UpdateAssignUserCommand(
    Guid Id,
    string Name,
    string Email,
    string Phone,
    DateTime StartDate,
    string Plant,
    string Role,
    string Permission
);