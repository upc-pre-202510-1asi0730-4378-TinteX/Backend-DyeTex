using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Model.Queries;
using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ARM.Domain.Services;

namespace TinteX.DyeText.Platform.ARM.Application.Internal.QueryServices;

public class TextileMachineQueryService(ITextileMachineRepository textileMachineRepository) : ITextileMachineQueryService
{
    public async Task<TextileMachine?> Handle(GetTextileMachineByIdQuery query)
    {
        return await textileMachineRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<TextileMachine>> Handle(GetAllTextileMachinesQuery query)
    {
        return await textileMachineRepository.ListAsync();
    }

    public async Task<TextileMachine?> Handle(GetTextileMachineByNameQuery query)
    {
        return await textileMachineRepository.FindByNameAsync(query.Name);
    }
}