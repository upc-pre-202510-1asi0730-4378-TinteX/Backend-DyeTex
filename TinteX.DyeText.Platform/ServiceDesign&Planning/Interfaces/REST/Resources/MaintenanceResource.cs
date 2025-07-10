namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

public record MaintenanceResource(
        Guid Id,
        string Description,
        DateTime ScheduledDate,
        string MachineId,
        string Status
    );