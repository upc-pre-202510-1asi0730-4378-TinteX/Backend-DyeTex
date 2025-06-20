using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;

namespace TinteX.DyeText.Platform.Analytics.Domain.Services
{
    public interface IMachineFailureRateQueryService
    {
        Task<IEnumerable<MachineFailureRate>> ListAsync();
        Task<MachineFailureRate?> FindByMachineIdAsync(Guid machineId);
    }
}