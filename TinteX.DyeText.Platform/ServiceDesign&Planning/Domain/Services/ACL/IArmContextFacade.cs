namespace TinteX.DyeText.Platform.ServiceDesign_Planning.Domain.Services;

/// <summary>
/// Defines an Anti-Corruption Layer interface to access external data from ARM (Assets and Resource Management).
/// </summary>
public interface IArmContextFacade {
    /// <summary>
    /// Retrieves the name of a textile machine by its unique identifier.
    /// </summary>
    /// <param name="textileMachineId">The ID of the textile machine.</param>
    /// <returns>The name of the machine, or "Unknown" if not found.</returns>
    Task<string> GetTextileMachineNameByIdAsync(Guid textileMachineId);
}