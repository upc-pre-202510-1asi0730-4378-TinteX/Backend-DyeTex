using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Application.Internal.CommandServices
{/*
    public class TaskDueStatusCountCommandService : ITaskDueStatusCountCommandService
    {
        private readonly ITaskRepository _taskRepo;
        private readonly ITaskDueStatusCountRepository _analyticsRepo;

        public TaskDueStatusCountCommandService(ITaskRepository taskRepo, ITaskDueStatusCountRepository analyticsRepo)
        {
            _taskRepo = taskRepo;
            _analyticsRepo = analyticsRepo;
        }

        public async Task Handle(UpdateTaskDueStatusCountCommand command)
        {
            var tasks = await _taskRepo.GetAllAsync();
            var now = DateTime.UtcNow;

            int overdue = tasks.Count(t => DateOnly.TryParse(t.DueDate, out var dueDate) && dueDate < DateOnly.FromDateTime(now));
            int upcoming = tasks.Count(t => DateOnly.TryParse(t.DueDate, out var dueDate) && dueDate < DateOnly.FromDateTime(now));

            var agg = new TaskDueStatusCount
            {
                OverdueCount = overdue,
                UpcomingCount = upcoming
            };

            await _analyticsRepo.UpsertAsync(agg);
        }
    }*/
}