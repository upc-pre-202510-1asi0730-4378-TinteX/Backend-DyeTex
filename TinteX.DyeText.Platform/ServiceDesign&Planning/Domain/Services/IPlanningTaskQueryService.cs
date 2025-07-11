using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IPlanningTaskQueryService
{
    Task<PlanningTask?> Handle(GetTaskByIdQuery query);
    Task<IEnumerable<PlanningTask>> Handle();
    Task<IEnumerable<PlanningTaskResource>> GetAllResourcesAsync();
    Task<PlanningTaskResource?> GetResourceByIdAsync(Guid id);
}