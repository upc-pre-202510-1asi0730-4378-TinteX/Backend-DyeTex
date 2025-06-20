using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Repositories
{
    public interface ITaskDueStatusCountRepository
    {
        Task<TaskDueStatusCount?> GetAsync();
        Task UpsertAsync(TaskDueStatusCount data);
    }
}