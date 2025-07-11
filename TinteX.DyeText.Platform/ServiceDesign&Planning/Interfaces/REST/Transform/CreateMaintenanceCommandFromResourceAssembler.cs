using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class CreateMaintenanceCommandFromResourceAssembler {
    public static CreateMaintenanceCommand ToCommandFromResource(CreateMaintenanceResource resource) {
        return new CreateMaintenanceCommand(
            resource.Description,
            resource.ScheduledDate,
            resource.MachineId,
            "Unknown" // El nombre de la máquina se obtendrá en el servicio a través del ARM
        );
    }
}