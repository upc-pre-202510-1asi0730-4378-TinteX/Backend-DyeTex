using TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;

public class Notifications
{
    public Guid Id { get; private set; }
    public string Message { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string TextileMachine { get; private set; }
    public bool MarkAsRead { get; private set; }

    public Notifications()
    {
        Id = Guid.NewGuid();
        Message = string.Empty;
        CreatedAt = DateTime.UtcNow;
        TextileMachine = string.Empty;
        MarkAsRead = false;
    }

    // Constructor para CreateNotificationsCommand
    public Notifications(CreateNotificationsCommand command)
    {
        Id = Guid.NewGuid();
        Message = command.Message;
        CreatedAt = DateTime.UtcNow;
        TextileMachine = command.TextileMachine;
        MarkAsRead = false;
    }

    // Método Update para UpdateNotificationsCommand
    public Notifications Update(UpdateNotificationsCommand command)
    {
        Id = command.Id;
        Message = command.Message;
        TextileMachine = command.TextileMachine;
        MarkAsRead = command.MarkAsRead;
        // CreatedAt normalmente no se actualiza, pero puedes agregarlo si lo necesitas

        return this;
    }

    public void MarkAsReadNotification()
    {
        MarkAsRead = true;
    }
}