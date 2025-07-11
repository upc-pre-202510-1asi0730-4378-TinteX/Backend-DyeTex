using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record CreateMaintenanceCommand(
    string Description,
    string ScheduledDate,
    Guid MachineId,
    string MachineName
    );