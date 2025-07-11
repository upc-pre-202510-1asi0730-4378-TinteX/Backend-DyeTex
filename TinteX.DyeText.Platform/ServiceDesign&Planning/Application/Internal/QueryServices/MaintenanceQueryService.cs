using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Resources;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Interfaces.REST.Transform;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.QueryServices;

public class MaintenanceQueryService : IMaintenanceQueryService
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IArmContextFacade _armContext;

    public MaintenanceQueryService(
        IMaintenanceRepository maintenanceRepository,
        IArmContextFacade armContext)
    {
        _maintenanceRepository = maintenanceRepository;
        _armContext = armContext;
    }


    public async Task<IEnumerable<Maintenance>> GetAllAsync()
    {
        return await _maintenanceRepository.GetAllAsync();
    }

    public async Task<Maintenance?> GetByIdAsync(MaintenanceId id)
    {
        return await _maintenanceRepository.GetByIdAsync(id);
    }
    
    public async Task<IEnumerable<MaintenanceResource>> GetAllResourcesAsync()
    {
        var maintenances = await _maintenanceRepository.GetAllAsync();

        var resources = new List<MaintenanceResource>();
        foreach (var maintenance in maintenances)
        {
            var machineName = await _armContext.GetTextileMachineNameByIdAsync(maintenance.MachineId);
            var resource = MaintenanceResourceFromEntityAssembler.ToResourceFromEntity(maintenance, machineName);
            resources.Add(resource);
        }

        return resources;
    }

    public async Task<MaintenanceResource?> GetResourceByIdAsync(MaintenanceId id)
    {
        var maintenance = await _maintenanceRepository.GetByIdAsync(id);
        if (maintenance == null) return null;

        var machineName = await _armContext.GetTextileMachineNameByIdAsync(maintenance.MachineId);
        return MaintenanceResourceFromEntityAssembler.ToResourceFromEntity(maintenance, machineName);
    }
}
