using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToResourceFromEntity(Notifications entity) =>
        new NotificationResource(
            entity.Id,
            entity.Message,
            entity.CreatedAt,
            entity.TextileMachine,
            entity.MarkAsRead
        );
}