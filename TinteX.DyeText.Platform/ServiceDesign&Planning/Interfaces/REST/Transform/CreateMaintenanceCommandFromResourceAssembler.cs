using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class CreateMaintenanceCommandFromResourceAssembler {
    public static CreateMaintenanceCommand ToCommandFromResource(CreateMaintenanceResource resource) {
        if (!Guid.TryParse(resource.MachineId, out var machineGuid))
            throw new FormatException("El MachineId proporcionado no tiene un formato válido de GUID.");

        return new CreateMaintenanceCommand(
            resource.Description,
            resource.ScheduledDate,
            new MachineId(machineGuid)
        );
    }
}