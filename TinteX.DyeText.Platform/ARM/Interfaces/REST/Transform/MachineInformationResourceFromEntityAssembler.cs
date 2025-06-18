using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public static class MachineInformationResourceFromEntityAssembler
{
    public static MachineInformationResource ToResourceFromEntity(MachineInformation entity) =>
        new MachineInformationResource(
            entity.Id,
            entity.TimeSpent,
            entity.DayProgress,
            entity.FailureRate,
            entity.AmountFailure
        );
}