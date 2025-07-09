namespace TinteX.DyeText.Platform.Monitoring.Interfaces.REST.Resources;

public record CreateNotificationResource(
    string Message,
    string TextileMachine
);