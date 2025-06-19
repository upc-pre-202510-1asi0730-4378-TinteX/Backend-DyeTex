using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
namespace TinteX.DyeText.Platform.Analytics.Domain.Services;

public interface IFailureCountCommandService
{
    Task Handle(UpdateMachineFailureCountsCommand command);
}


