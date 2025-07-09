using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Services;

public interface INotificationCommandService
{
    Task<Notifications?> Handle(CreateNotificationsCommand command);

    Task<Notifications?> Handle(UpdateNotificationsCommand command);
}