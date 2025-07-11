using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

public static class MaintenanceResourceFromEntityAssembler
{
    public static MaintenanceResource ToResourceFromEntity(Maintenance entity, string machineName)
    {
        return new MaintenanceResource(
            Id: entity.Id.Value,
            Description: entity.Description,
            ScheduledDate: entity.ScheduledDate,
            MachineId: entity.MachineId.ToString(),
            MachineName: machineName,
            Status: entity.Status.ToString()
        );
    }
}