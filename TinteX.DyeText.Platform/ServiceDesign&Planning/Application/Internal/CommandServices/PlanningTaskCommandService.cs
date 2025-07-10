using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.CommandServices;

public class PlanningTaskCommandService : IPlanningTaskCommandService {
    private readonly IPlanningTaskRepository _taskRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlanningTaskCommandService(IPlanningTaskRepository taskRepository, IUnitOfWork unitOfWork) {
        _taskRepository = taskRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<TaskId> Handle(CreatePlanningTaskCommand command) {
        var task = new PlanningTask(command);
        await _taskRepository.AddAsync(task);
        await _unitOfWork.CompleteAsync();
        return task.Id;
    }

    public async Task Handle(UpdateTaskNameCommand command) {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task is null) return;

        task.Rename(command.NewName);
        _taskRepository.Update(task);
        await _unitOfWork.CompleteAsync();
    }
    
    public async Task Handle(DeleteTaskCommand command) {
        var task = await _taskRepository.GetByIdAsync(command.TaskId);
        if (task == null)
            throw new ArgumentException($"Task with ID {command.TaskId.Value} does not exist");

        await _taskRepository.DeleteAsync(task);
        await _unitOfWork.CompleteAsync();
    }
}