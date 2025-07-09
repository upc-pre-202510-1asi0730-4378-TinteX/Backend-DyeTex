namespace TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;

public record CreateNotificationsCommand(
    string Message,
    string TextileMachine,
    bool MarkAsRead = false
);