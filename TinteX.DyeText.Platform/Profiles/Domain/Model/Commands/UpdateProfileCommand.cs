// Domain/Model/Commands/UpdateProfileCommand.cs
namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

public record UpdateProfileCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    bool MembershipActive,
    string Theme
);