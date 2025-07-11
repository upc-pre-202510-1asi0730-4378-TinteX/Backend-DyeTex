using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Queries;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notifications>> Handle(GetAllNotificationsQuery query);
    Task<Notifications?> Handle(GetNotificationsByIdQuery query);
}