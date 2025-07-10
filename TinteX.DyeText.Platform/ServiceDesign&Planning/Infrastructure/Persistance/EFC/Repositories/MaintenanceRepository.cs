using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Infrastructure.Persistance.EFC.Repositories;

public class MaintenanceRepository : IMaintenanceRepository {
    private readonly AppDbContext _context;

    public MaintenanceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Maintenance>> GetAllAsync() {
        return await _context.Maintenances.ToListAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(MaintenanceId id)
    {
        return await _context.Maintenances.FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task AddAsync(Maintenance maintenance)
    {
        await _context.Maintenances.AddAsync(maintenance);
    }

    public void Update(Maintenance maintenance)
    {
        _context.Maintenances.Update(maintenance);
    }

    public void Remove(Maintenance maintenance)
    {
        _context.Maintenances.Remove(maintenance);
    }
}