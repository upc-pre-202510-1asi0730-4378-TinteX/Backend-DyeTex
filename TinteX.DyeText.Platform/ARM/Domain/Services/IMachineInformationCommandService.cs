using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Services;

public interface IMachineInformationCommandService
{
    Task<MachineInformation?> Handle(CreateMachineInformationCommand command);
    
    Task<MachineInformation?> Handle(UpdateMachineInformationCommand command);
}