using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace TinteX.DyeText.Platform.Monitoring.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context)
    : BaseRepository<Notifications>(context),
        INotificationRepository
{
    public async Task<Notifications?> FindByIdAsync(Guid id)
    {
        return await Context.Set<Notifications>().FirstOrDefaultAsync(n => n.Id == id);
    }
}