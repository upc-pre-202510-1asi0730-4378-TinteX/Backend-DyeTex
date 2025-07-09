using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Queries;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;

namespace TinteX.DyeText.Platform.Monitoring.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository)
    : INotificationQueryService
{
    public async Task<Notifications?> Handle(GetNotificationsByIdQuery query)
    {
        return await notificationRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Notifications>> Handle(GetAllNotificationsQuery query)
    {
        return await notificationRepository.ListAsync();
    }
}