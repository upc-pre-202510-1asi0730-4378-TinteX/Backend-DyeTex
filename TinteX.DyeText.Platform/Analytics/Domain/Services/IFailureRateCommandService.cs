using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Analytics.Domain.Services
{
    public interface IFailureRateCommandService
    {
        Task Handle(UpdateMachineFailureRatesCommand command);
    }
}