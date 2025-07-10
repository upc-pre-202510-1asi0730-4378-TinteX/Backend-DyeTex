using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.Commands;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Model.valueObjects;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.CommandServices;

public class MaintenanceCommandService : IMaintenanceCommandService
{
    private readonly IMaintenanceRepository _maintenanceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MaintenanceCommandService(IMaintenanceRepository maintenanceRepository, IUnitOfWork unitOfWork)
    {
        _maintenanceRepository = maintenanceRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<MaintenanceId> Handle(CreateMaintenanceCommand command)
    {
        var maintenance = new Maintenance(command);
        await _maintenanceRepository.AddAsync(maintenance);
        await _unitOfWork.CompleteAsync();
        return maintenance.Id;
    }

    public async Task Handle(UpdateMaintenanceStatusCommand command)
    {
        var maintenance = await _maintenanceRepository.GetByIdAsync(command.MaintenanceId);
        if (maintenance == null) throw new KeyNotFoundException("Maintenance not found.");
        maintenance.UpdateStatus(command.Status);
        await _unitOfWork.CompleteAsync();
    }

    public async Task Handle(DeleteMaintenanceCommand command)
    {
        var maintenance = await _maintenanceRepository.GetByIdAsync(command.MaintenanceId);
        if (maintenance == null) throw new KeyNotFoundException("Maintenance not found.");
        _maintenanceRepository.Remove(maintenance);
        await _unitOfWork.CompleteAsync();
    }
}