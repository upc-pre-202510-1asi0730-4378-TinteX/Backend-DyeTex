namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record CreateMaintenanceResource(
    string Description,
    string ScheduledDate,
    Guid MachineId
);
