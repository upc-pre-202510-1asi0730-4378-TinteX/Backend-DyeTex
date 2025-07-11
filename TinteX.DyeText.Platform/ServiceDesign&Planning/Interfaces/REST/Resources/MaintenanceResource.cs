namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record MaintenanceResource(
        Guid Id,
        string Description,
        string ScheduledDate,
        string MachineId,
        string MachineName,
        string Status
    );