namespace TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;

public record UpdateNotificationsCommand(
    Guid Id,
    string Message,
    string TextileMachine,
    bool MarkAsRead
);