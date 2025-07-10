using TinteX.DyeText.Platform.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace TinteX.DyeText.Platform.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}