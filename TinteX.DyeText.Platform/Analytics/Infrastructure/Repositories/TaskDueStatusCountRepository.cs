using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;

namespace TinteX.DyeText.Platform.Analytics.Infrastructure.Repositories
{
    public class TaskDueStatusCountRepository(AppDbContext context) : ITaskDueStatusCountRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<TaskDueStatusCount?> GetAsync()
        {
            return await _context.Set<TaskDueStatusCount>().FirstOrDefaultAsync();
        }

        public async Task UpsertAsync(TaskDueStatusCount data)
        {
            var existing = await GetAsync();
            if (existing is null)
                await _context.Set<TaskDueStatusCount>().AddAsync(data);
            else
            {
                existing.OverdueCount = data.OverdueCount;
                existing.UpcomingCount = data.UpcomingCount;
                _context.Update(existing);
            }

            await _context.SaveChangesAsync();
        }
    }
}