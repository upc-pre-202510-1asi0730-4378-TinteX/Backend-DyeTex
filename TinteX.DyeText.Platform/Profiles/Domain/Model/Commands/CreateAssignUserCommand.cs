﻿// TinteX.DyeText.Platform/Profiles/Domain/Model/Commands/CreateAssignUserCommand.cs
namespace TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;

public record CreateAssignUserCommand(
    string Name,
    string Email,
    string Phone,
    string StartDate,
    string Plant,
    string Role,
    string Permission
);