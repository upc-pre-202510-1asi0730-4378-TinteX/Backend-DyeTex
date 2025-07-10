using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class MaintenanceQueryService : IMaintenanceQueryService {
    private readonly IMaintenanceRepository _maintenanceRepository;

    public MaintenanceQueryService(IMaintenanceRepository maintenanceRepository) {
        _maintenanceRepository = maintenanceRepository;
    }

    public async Task<IEnumerable<Maintenance>> GetAllAsync() {
        return await _maintenanceRepository.GetAllAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(MaintenanceId id) {
        return await _maintenanceRepository.GetByIdAsync(id);
    }
}