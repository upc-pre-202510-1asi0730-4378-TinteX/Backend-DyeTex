using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface ITaskCommandService {
    Task<Guid> Handle(CreateTaskCommand command);
    Task Handle(UpdateTaskNameCommand command);
    Task Handle(UpdateTaskDueDateCommand command);
    Task Handle(DeleteTaskCommand command);
}