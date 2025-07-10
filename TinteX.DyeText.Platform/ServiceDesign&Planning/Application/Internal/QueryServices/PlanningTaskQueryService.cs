using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class PlanningTaskQueryService(IPlanningTaskRepository taskRepository) : IPlanningTaskQueryService
{
    public async Task<PlanningTask?> Handle(GetTaskByIdQuery query)
    {
        return await taskRepository.GetByIdAsync(query.TaskId);
    }

    public async Task<IEnumerable<PlanningTask>> Handle()
    {
        return await taskRepository.GetAllAsync();
    }
}