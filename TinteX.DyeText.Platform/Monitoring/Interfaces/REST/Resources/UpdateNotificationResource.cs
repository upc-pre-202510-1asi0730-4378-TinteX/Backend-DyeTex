namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

public record UpdateNotificationResource(
    string Message,
    string TextileMachine,
    bool MarkAsRead
);