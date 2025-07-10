using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Transform;

public static class AssignUserResourceFromEntityAssembler
{
    public static AssignUserResource ToResourceFromEntity(AssignUser entity) =>
        new AssignUserResource(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.Phone,
            entity.StartDate,
            entity.Plant,
            entity.Role,
            entity.Permission
        );
}