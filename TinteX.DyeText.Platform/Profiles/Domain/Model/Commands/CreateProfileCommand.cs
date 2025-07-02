namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

// Ruta: TinteX.DyeText.Platform/Profiles/Domain/Model/Commands/CreateProfileCommand.cs
public record CreateProfileCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    bool MembershipActive,
    string Theme
);