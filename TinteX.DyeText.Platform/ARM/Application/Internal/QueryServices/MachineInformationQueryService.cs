using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ARM.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.QueryServices;

public class MachineInformationQueryService(IMachineInformationRepository machineInformationRepository)
: IMachineInformationQueryService
{
    public async Task<MachineInformation?> Handle(GetMachineInformationById query)
    {
        return await machineInformationRepository.FindByIdAsync(query.Id);
    }
}