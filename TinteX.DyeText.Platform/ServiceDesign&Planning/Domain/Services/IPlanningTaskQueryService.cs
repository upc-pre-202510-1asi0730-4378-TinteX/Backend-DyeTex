using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IPlanningTaskQueryService
{
    Task<PlanningTask?> Handle(GetTaskByIdQuery query);
    Task<IEnumerable<PlanningTask>> Handle();
}