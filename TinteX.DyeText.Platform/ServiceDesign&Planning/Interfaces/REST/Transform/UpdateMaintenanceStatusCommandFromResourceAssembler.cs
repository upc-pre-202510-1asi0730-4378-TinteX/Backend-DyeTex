using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class UpdateMaintenanceStatusCommandFromResourceAssembler
{
    public static UpdateMaintenanceStatusCommand ToCommandFromResource(Guid id, UpdateMaintenanceStatusResource resource)
    {
        var status = Enum.Parse<ETaskStatus>(resource.NewStatus, ignoreCase: true);
        return new UpdateMaintenanceStatusCommand(new MaintenanceId(id), status);
    }
}