using TinteX.DyeText.Platform.Monitoring.Domain.Model.Aggregate;
using TinteX.DyeText.Platform.Monitoring.Domain.Model.Commands;
using TinteX.DyeText.Platform.Monitoring.Domain.Repositories;
using TinteX.DyeText.Platform.Monitoring.Domain.Services;
using TinteX.DyeText.Platform.Shared.Domain.Repositories;

namespace TinteX.DyeText.Platform.Monitoring.Application.Internal.CommandServices;

public class NotificationCommandService(
    INotificationRepository notificationRepository,
    IUnitOfWork unitOfWork
) : INotificationCommandService
{
    public async Task<Notifications?> Handle(CreateNotificationsCommand command)
    {
        var notification = new Notifications(command);
        await notificationRepository.AddAsync(notification);
        await unitOfWork.CompleteAsync();
        return notification;
    }

    public async Task<Notifications?> Handle(UpdateNotificationsCommand command)
    {
        var notification = await notificationRepository.FindByIdAsync(command.Id);
        if (notification == null)
            throw new InvalidOperationException($"Notification with Id {command.Id} does not exist.");

        var updatedNotification = notification.Update(command);

        try
        {
            notificationRepository.Update(updatedNotification);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return updatedNotification;
    }
}