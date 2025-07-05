using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class TaskQueryService : ITaskQueryService {
    private readonly ITaskRepository _taskRepository;

    public TaskQueryService(ITaskRepository taskRepository) {
        _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskView>> Handle(GetAllTasksQuery query) {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(t => new TaskView(t.Id, t.Name, t.DueDate));
    }

    public async Task<TaskView?> Handle(GetTaskByIdQuery query) {
        var task = await _taskRepository.GetByIdAsync(query.TaskId);
        return task == null ? null : new TaskView(task.Id, task.Name, task.DueDate);
    }

    public async Task<IEnumerable<TaskView>> Handle(GetTasksByStatusQuery query) {
        var tasks = await _taskRepository.GetAllAsync();
        return tasks.Select(t => new TaskView(t.Id, t.Name, t.DueDate));
    }
}