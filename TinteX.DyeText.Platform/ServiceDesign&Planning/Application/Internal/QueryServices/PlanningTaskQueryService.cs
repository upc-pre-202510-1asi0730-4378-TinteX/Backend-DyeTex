using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class PlanningTaskQueryService : IPlanningTaskQueryService
{
    private readonly IPlanningTaskRepository _taskRepository;
    private readonly IArmContextFacade _armContext;

    public PlanningTaskQueryService(
        IPlanningTaskRepository taskRepository,
        IArmContextFacade armContext)
    {
        _taskRepository = taskRepository;
        _armContext = armContext;
    }


    public async Task<PlanningTask?> Handle(GetTaskByIdQuery query)
    {
        return await _taskRepository.GetByIdAsync(query.TaskId);
    }

    public async Task<IEnumerable<PlanningTask>> Handle()
    {
        return await _taskRepository.GetAllAsync();
    }


    public async Task<PlanningTaskResource?> GetResourceByIdAsync(Guid id)
    {
        var task = await _taskRepository.GetByIdAsync(new TaskId(id));
        if (task == null) return null;

        var machineName = await _armContext.GetTextileMachineNameByIdAsync(task.TextileMachineId);
        return PlanningTaskResourceFromEntityAssembler.ToResourceFromEntity(task, machineName);
    }

    public async Task<IEnumerable<PlanningTaskResource>> GetAllResourcesAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        var resourceList = new List<PlanningTaskResource>();

        foreach (var task in tasks)
        {
            var machineName = await _armContext.GetTextileMachineNameByIdAsync(task.TextileMachineId);
            var resource = PlanningTaskResourceFromEntityAssembler.ToResourceFromEntity(task, machineName);
            resourceList.Add(resource);
        }

        return resourceList;
    }
}
