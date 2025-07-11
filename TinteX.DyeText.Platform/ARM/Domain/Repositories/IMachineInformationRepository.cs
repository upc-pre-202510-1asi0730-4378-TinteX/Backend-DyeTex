using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Domain.Repositories;

public interface IMachineInformationRepository : IBaseRepository<MachineInformation>
{
    Task<MachineInformation?> FindByIdAsync(Guid id);
}