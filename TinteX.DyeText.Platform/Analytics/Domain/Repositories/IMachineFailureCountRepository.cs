using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Repositories;

public interface IMachineFailureCountRepository
{
    Task<IEnumerable<MachineFailureCount>> ListAsync();
    Task<MachineFailureCount?> FindByMachineIdAsync(Guid machineId);
    Task AddAsync(MachineFailureCount count);
    void Update(MachineFailureCount count);

    async Task UpsertAsync(MachineFailureCount count)
    {
        var existing = await FindByMachineIdAsync(count.MachineId);
        if (existing is null)
            await AddAsync(count);
        else
        {
            existing.Count = count.Count;
            Update(existing);
        }
    }
}

