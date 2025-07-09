using TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;
using TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Transform;

public class UpdateNotificationCommandFromResourceAssembler
{
    public static UpdateNotificationsCommand ToCommandFromResource(UpdateNotificationResource resource, Guid id)
    {
        return new UpdateNotificationsCommand(
            id,
            resource.Message,
            resource.TextileMachine,
            resource.MarkAsRead
        );
    }
}