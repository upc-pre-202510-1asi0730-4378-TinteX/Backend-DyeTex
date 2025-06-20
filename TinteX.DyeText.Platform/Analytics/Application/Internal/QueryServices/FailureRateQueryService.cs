using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Analytics.Domain.Services;

namespace TinteX.DyeText.Platform.Analytics.Application.Internal.QueryServices
{
    public class FailureRateQueryService : IMachineFailureRateQueryService
    {
        private readonly IMachineFailureRateRepository _repo;

        public FailureRateQueryService(IMachineFailureRateRepository repo)
            => _repo = repo;

        public Task<IEnumerable<MachineFailureRate>> ListAsync() => _repo.ListAsync();
        public Task<MachineFailureRate?> FindByMachineIdAsync(Guid id) => _repo.FindByMachineIdAsync(id);
    }
}