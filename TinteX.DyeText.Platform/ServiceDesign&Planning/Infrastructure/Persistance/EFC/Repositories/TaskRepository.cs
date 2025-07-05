using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;
using TaskEntity = TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates.Task;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Repositories;

public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
{
    public TaskRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<TaskEntity>> GetAllAsync()
    {
        return await Context.Set<TaskEntity>().ToListAsync();
    }

    public async Task<TaskEntity?> GetByIdAsync(Guid id)
    {
        return await Context.Set<TaskEntity>().FindAsync(id);
    }

    public async Task AddAsync(TaskEntity task)
    {
        await Context.Set<TaskEntity>().AddAsync(task);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskEntity task)
    {
        Context.Set<TaskEntity>().Update(task);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TaskEntity task)
    {
        Context.Set<TaskEntity>().Remove(task);
        await Context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await Context.Set<TaskEntity>().AnyAsync(t => t.Id == id);
    }
}