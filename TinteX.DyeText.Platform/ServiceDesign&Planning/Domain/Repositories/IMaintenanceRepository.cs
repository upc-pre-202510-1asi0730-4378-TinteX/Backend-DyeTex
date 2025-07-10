using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;

public interface IMaintenanceRepository {
    Task<IEnumerable<Maintenance>> GetAllAsync();
    Task<Maintenance?> GetByIdAsync(MaintenanceId id);
    Task AddAsync(Maintenance maintenance);
    void Update(Maintenance maintenance);
    void Remove(Maintenance maintenance);
}