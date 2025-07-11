namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

public record NotificationResource(
    Guid Id,
    string Message,
    DateTime CreatedAt,
    string TextileMachine,
    bool MarkAsRead
);