using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Repositories
{
    public interface IMachineFailureRateRepository
    {
        Task<IEnumerable<MachineFailureRate>> ListAsync();
        Task<MachineFailureRate?> FindByMachineIdAsync(Guid machineId);
        Task UpsertAsync(MachineFailureRate rate);
    }
}