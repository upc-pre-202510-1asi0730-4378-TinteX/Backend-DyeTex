using System;
using System.Threading.Tasks;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;
using DomainTask = TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates.Task;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.CommandServices;

public class TaskCommandService : ITaskCommandService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TaskCommandService(
        ITaskRepository taskRepository,
        IUnitOfWork unitOfWork
    )
    {
        _taskRepository = taskRepository ?? throw new ArgumentNullException(nameof(taskRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<Guid> Handle(CreateTaskCommand command)
    {
        var task = new DomainTask(command.Name, command.DueDate);
        await _taskRepository.AddAsync(task);
        await _unitOfWork.CompleteAsync();
        return task.Id;
    }

    public async Task Handle(UpdateTaskNameCommand command)
    {
        var task = await GetTaskOrThrow(command.TaskId);
        task.UpdateName(command.NewName);
        await _taskRepository.UpdateAsync(task);
        await _unitOfWork.CompleteAsync();
    }

    public async Task Handle(UpdateTaskDueDateCommand command)
    {
        var task = await GetTaskOrThrow(command.TaskId);
        task.UpdateDueDate(command.NewDueDate);
        await _taskRepository.UpdateAsync(task);
        await _unitOfWork.CompleteAsync();
    }

    public async Task Handle(DeleteTaskCommand command)
    {
        var task = await GetTaskOrThrow(command.TaskId);
        await _taskRepository.DeleteAsync(task);
        await _unitOfWork.CompleteAsync();
    }

    private async Task<DomainTask> GetTaskOrThrow(Guid taskId)
    {
        var task = await _taskRepository.GetByIdAsync(taskId);
        if (task == null)
            throw new InvalidOperationException($"Task with ID {taskId} not found");
        return task;
    }
}