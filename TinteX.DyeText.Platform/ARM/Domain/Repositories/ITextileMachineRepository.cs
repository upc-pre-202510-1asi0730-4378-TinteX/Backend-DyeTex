using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.ARM.Domain.Repositories;

public interface ITextileMachineRepository : IBaseRepository<TextileMachine>
{
    Task<TextileMachine?> FindByIdAsync(Guid id);
    
    Task<TextileMachine?> FindByNameAsync(string name);
}