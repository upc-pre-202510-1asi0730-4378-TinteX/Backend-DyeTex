using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public static class CreateTextileMachineCommandFromResourceAssembler
{
    public static CreateTextileMachineCommand ToCommandFromResource(CreateTextileMachineResource resource)
    {
        return new CreateTextileMachineCommand(
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