using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public static class TextileMachineResourceFromEntityAssembler
{
    public static TextileMachineResource toResourceFromEntity(TextileMachine entity) =>
        new TextileMachineResource(
            entity.Id,
            entity.MachineInformationId,
            entity.Name,
            entity.AssetType,
            entity.Status,
            entity.SerialNumber,
            entity.Floor,
            entity.Zone,
            entity.DateInstallation
        );
}