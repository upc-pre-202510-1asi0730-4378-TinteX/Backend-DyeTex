using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IMaintenanceCommandService {
    Task<MaintenanceId> Handle(CreateMaintenanceCommand command);
    Task Handle(UpdateMaintenanceStatusCommand command);
    Task Handle(DeleteMaintenanceCommand command);
}