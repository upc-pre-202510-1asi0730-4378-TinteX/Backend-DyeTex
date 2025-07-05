using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface ITaskQueryService {
    Task<IEnumerable<TaskView>> Handle(GetAllTasksQuery query);
    Task<TaskView?> Handle(GetTaskByIdQuery query);
    Task<IEnumerable<TaskView>> Handle(GetTasksByStatusQuery query);
}