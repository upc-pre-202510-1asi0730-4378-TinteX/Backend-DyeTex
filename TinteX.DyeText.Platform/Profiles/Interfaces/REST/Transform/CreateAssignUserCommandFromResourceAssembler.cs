using TinteX.DyeText.Platform.Profiles.Domain.Model.Commands;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Transform;

public static class CreateAssignUserCommandFromResourceAssembler
{
    public static CreateAssignUserCommand ToCommandFromResource(CreateAssignUserResource resource)
    {
        return new CreateAssignUserCommand(
            resource.Name,
            resource.Email,
            resource.Phone,
            resource.StartDate,
            resource.Plant,
            resource.Role,
            resource.Permission
        );
    }
}