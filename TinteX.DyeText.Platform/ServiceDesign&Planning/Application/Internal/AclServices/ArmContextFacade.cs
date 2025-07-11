using TinteX.DyeText.Platform.ARM.Domain.Repositories;
using TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Application.Internal.AclServices;

/// <summary>
/// Provides access to ARM data (TextileMachine) through a protected Anti-Corruption Layer.
/// </summary>
public class ArmContextFacade : IArmContextFacade {
    private readonly ITextileMachineRepository _textileMachineRepository;

    public ArmContextFacade(ITextileMachineRepository textileMachineRepository)
    {
        _textileMachineRepository = textileMachineRepository;
    }

    public async Task<string> GetTextileMachineNameByIdAsync(Guid textileMachineId)
    {
        var machine = await _textileMachineRepository.FindByIdAsync(textileMachineId);

        if (machine == null)
            Console.WriteLine($"No machine found with ID: {textileMachineId}");
        else
            Console.WriteLine($"Found machine: {machine.Name} (ID: {textileMachineId})");

        return machine?.Name ?? "Unknown";
    }
}