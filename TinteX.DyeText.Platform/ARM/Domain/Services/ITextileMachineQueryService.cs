using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.ARM.Domain.Services;

public interface ITextileMachineQueryService
{
    Task<TextileMachine?> Handle(GetTextileMachineByIdQuery query);
    
    Task<IEnumerable<TextileMachine>> Handle(GetAllTextileMachinesQuery query);
    
    Task<TextileMachine?> Handle(GetTextileMachineByNameQuery query);
}