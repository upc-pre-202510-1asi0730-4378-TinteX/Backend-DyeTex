using System;
using System.Threading.Tasks;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Entities;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace ServiceDesing.Application.Internal.CommandServices;

public class TaskCommandService : ITaskCommandService {
    private readonly ITaskRepository _taskRepository;

    public TaskCommandService(ITaskRepository taskRepository) {
        _taskRepository = taskRepository;
    }

    public async Task<Guid> Handle(CreateTaskCommand command) {
        var task = new TaskEntity(command.Name, command.DueDate);
        await _taskRepository.AddAsync(task);
        return task.Id;
    }

    public async Task Handle(UpdateTaskNameCommand command) {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task == null) throw new Exception("Task not found");

        task.Name = command.NewName;
        await _taskRepository.UpdateAsync(task);
    }

    public async Task Handle(UpdateTaskDueDateCommand command) {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task == null) throw new Exception("Task not found");

        task.DueDate = command.NewDueDate;
        await _taskRepository.UpdateAsync(task);
    }

    public async Task Handle(DeleteTaskCommand command) {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task == null) throw new Exception("Task not found");

        await _taskRepository.DeleteAsync(task);
    }
}