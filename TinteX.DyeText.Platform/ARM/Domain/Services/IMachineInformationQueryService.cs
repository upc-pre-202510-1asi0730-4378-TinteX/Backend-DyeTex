using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.ARM.Domain.Services;

public interface IMachineInformationQueryService
{
    Task<MachineInformation?> Handle(GetMachineInformationById query);
    
    Task<IEnumerable<MachineInformation>> Handle(GetAllMachineInformationsQuery query);
    
}