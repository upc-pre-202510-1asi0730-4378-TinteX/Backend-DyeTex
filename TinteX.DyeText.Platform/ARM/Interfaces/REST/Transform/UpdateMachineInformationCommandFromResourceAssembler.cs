using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public class UpdateMachineInformationCommandFromResourceAssembler
{
    public static UpdateMachineInformationCommand ToCommandFromResource(UpdateMachineInformationResource resource, Guid id)
    {
        return new UpdateMachineInformationCommand(
             id,
             resource.TimeSpent,
             resource.DayProgress,
             resource.FailureRate,
             resource.AmountFailure
        );
    }
}