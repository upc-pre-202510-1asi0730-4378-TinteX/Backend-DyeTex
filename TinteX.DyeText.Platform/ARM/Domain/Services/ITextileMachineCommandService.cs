using TinteX.DyeText.Platform.ARM.Domain.Model.Commands;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Services;

public interface ITextileMachineCommandService
{
    Task<TextileMachine?> Handle(CreateTextileMachineCommand command);
    
    Task<TextileMachine?> Handle(UpdateTextileMachineCommand command);
}