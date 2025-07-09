using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.Monitoring.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notifications>
{
    Task<Notifications?> FindByIdAsync(Guid id);
}