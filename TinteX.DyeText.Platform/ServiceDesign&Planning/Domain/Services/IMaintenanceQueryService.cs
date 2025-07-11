using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

public interface IMaintenanceQueryService
{
    Task<IEnumerable<Maintenance>> GetAllAsync();
    Task<Maintenance?> GetByIdAsync(MaintenanceId id);
    Task<IEnumerable<MaintenanceResource>> GetAllResourcesAsync();
    Task<MaintenanceResource?> GetResourceByIdAsync(MaintenanceId id);
}