using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace TinteX.DyeText.Platform.Analytics.Infrastructure.Repositories
{
    public class MachineFailureRateRepository : IMachineFailureRateRepository
    {
        private readonly AppDbContext _context;

        public MachineFailureRateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MachineFailureRate>> ListAsync()
            => await _context.Set<MachineFailureRate>().ToListAsync();

        public async Task<MachineFailureRate?> FindByMachineIdAsync(Guid machineId)
            => await _context.Set<MachineFailureRate>().FirstOrDefaultAsync(x => x.MachineId == machineId);

        public async Task AddAsync(MachineFailureRate rate)
        {
            await _context.Set<MachineFailureRate>().AddAsync(rate);
            await _context.SaveChangesAsync();
        }

        public void Update(MachineFailureRate rate)
        {
            _context.Set<MachineFailureRate>().Update(rate);
            _context.SaveChanges();
        }

        public async Task UpsertAsync(MachineFailureRate rate)
        {
            var existing = await FindByMachineIdAsync(rate.MachineId);
            if (existing == null) await AddAsync(rate);
            else
            {
                existing.MachineName = rate.MachineName;
                existing.Rate = rate.Rate;
                Update(existing);
            }
        }
    }
}