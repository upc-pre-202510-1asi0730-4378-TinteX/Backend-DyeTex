using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TinteX.DyeText.Platform.Analytics.Infrastructure.Repositories
{
    public class MachineFailureCountRepository : IMachineFailureCountRepository
    {
        private readonly AppDbContext _context;

        public MachineFailureCountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MachineFailureCount>> ListAsync()
            => await _context.Set<MachineFailureCount>().ToListAsync();

        public async Task<MachineFailureCount?> FindByMachineIdAsync(Guid machineId)
            => await _context.Set<MachineFailureCount>()
                .FirstOrDefaultAsync(x => x.MachineId == machineId);

        public async Task AddAsync(MachineFailureCount count)
        {
            await _context.Set<MachineFailureCount>().AddAsync(count);
            await _context.SaveChangesAsync();
        }

        public void Update(MachineFailureCount count)
        {
            _context.Set<MachineFailureCount>().Update(count);
            _context.SaveChanges();
        }

        public async Task UpsertAsync(MachineFailureCount count)
        {
            var existing = await FindByMachineIdAsync(count.MachineId);
            if (existing != null)
            {
                existing.Count = count.Count;
                existing.MachineName = count.MachineName;
                Update(existing);
            }
            else
            {
                await AddAsync(count);
            }
        }
    }
}



