using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Repositories;

public class PlanningTaskRepository : IPlanningTaskRepository {
    private readonly AppDbContext _context;

    public PlanningTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PlanningTask>> GetAllAsync()
    {
        return await _context.PlanningTasks.ToListAsync();
    }

    public async Task<PlanningTask?> GetByIdAsync(TaskId id)
    {
        return await _context.PlanningTasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task AddAsync(PlanningTask task)
    {
        await _context.PlanningTasks.AddAsync(task);
    }

    public void Update(PlanningTask task)
    {
        _context.PlanningTasks.Update(task);
    }
    
    public async Task DeleteAsync(PlanningTask task)
    {
        _context.PlanningTasks.Remove(task);
    }

}