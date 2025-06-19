using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Analytics.Domain.Services;

namespace TinteX.DyeText.Platform.Analytics.Application.Internal.QueryServices
{
    public class FailuresCountQueryService : IMachinesFailureCountQueryService
    {
        private readonly IMachineFailureCountRepository _repo;

        public FailuresCountQueryService(IMachineFailureCountRepository repo)
            => _repo = repo;

        public Task<IEnumerable<MachineFailureCount>> ListAsync()
            => _repo.ListAsync();

        public Task<MachineFailureCount?> FindByMachineIdAsync(Guid machineId)
            => _repo.FindByMachineIdAsync(machineId);
    }
    
    
}