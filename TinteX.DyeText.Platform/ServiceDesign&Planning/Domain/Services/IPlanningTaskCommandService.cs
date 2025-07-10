using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IPlanningTaskCommandService {
    Task<TaskId> Handle(CreatePlanningTaskCommand command);
    Task Handle(UpdateTaskNameCommand command);
    Task Handle(DeleteTaskCommand command);
}