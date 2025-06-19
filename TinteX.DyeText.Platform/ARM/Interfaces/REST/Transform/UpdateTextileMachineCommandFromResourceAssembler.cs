using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public static class UpdateTextileMachineCommandFromResourceAssembler
{
    public static UpdateTextileMachineCommand toCommandFromResource(UpdateTextileMachineResource resource, Guid id)
    {
        return new UpdateTextileMachineCommand(
            id,
            resource.MachineInformationId,
            resource.Name,
            resource.AssetType,
            resource.Status,
            resource.SerialNumber,
            resource.Floor,
            resource.Zone,
            resource.DateInstallation
        );
    }
}