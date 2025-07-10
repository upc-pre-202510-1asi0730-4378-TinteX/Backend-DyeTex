using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

public record UpdateMaintenanceStatusCommand(
        MaintenanceId MaintenanceId,
        ETaskStatus Status
    );