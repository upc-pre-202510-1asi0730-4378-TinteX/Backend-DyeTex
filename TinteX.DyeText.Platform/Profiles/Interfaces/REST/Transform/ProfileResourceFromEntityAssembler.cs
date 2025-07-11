using TinteX.DyeText.Platform.Profiles.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Profiles.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Profiles.Interfaces.REST.Transform;

/// <summary>
/// Assembler class to convert Profile entity to ProfileResource 
/// </summary>
public static class ProfileResourceFromEntityAssembler
{
    /// <summary>
    /// Convert Profile entity to ProfileResource 
    /// </summary>
    /// <param name="entity">
    /// <see cref="Profile"/> entity to convert
    /// </param>
    /// <returns>
    /// <see cref="ProfileResource"/> converted from <see cref="Profile"/> entity
    /// </returns>
    public static ProfileResource ToResourceFromEntity(Profile e)
        => new(
            e.Id,
            e.FullName,
            e.EmailAddress,
            e.Phone,
            e.MembershipActive,
            e.Theme
        );
}