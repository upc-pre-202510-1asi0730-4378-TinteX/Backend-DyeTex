using TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;
using TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Transform;

public static class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationsCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationsCommand(
            resource.Message,
            resource.TextileMachine
        );
    }
}