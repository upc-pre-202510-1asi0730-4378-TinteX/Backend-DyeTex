using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;

public interface IPlanningTaskRepository {
    Task<IEnumerable<PlanningTask>> GetAllAsync();
    Task<PlanningTask?> GetByIdAsync(TaskId id);
    Task AddAsync(PlanningTask task);
    void Update(PlanningTask task);
    Task DeleteAsync(PlanningTask task);
}