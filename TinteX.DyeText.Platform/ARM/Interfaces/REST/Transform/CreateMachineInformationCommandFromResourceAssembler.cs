using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.ARM.Interfaces.REST.Transform;

public static class CreateMachineInformationCommandFromResourceAssembler
{
    public static CreateMachineInformationCommand ToCommandFromResource(CreateMachineInformationResource resource)
    {
        return new CreateMachineInformationCommand(
            resource.TimeSpent,
            resource.DayProgress,
            resource.FailureRate,
            resource.AmountFailure,
            resource.UserId,
            resource.Temperature,
            resource.Vibration,
            resource.Energy,
            resource.Speed
        );
    }
}