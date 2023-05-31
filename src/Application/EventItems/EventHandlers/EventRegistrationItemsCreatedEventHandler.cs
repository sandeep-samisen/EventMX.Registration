using EventMX.Domain.Events.EventItemsEvents;
using EventMX.Registration.Domain.Events.EventRegistrationItemsEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EventMX.Application.EventItemsService.EventHandlers;
public class EventRegistrationItemsCreatedEventHandler : INotificationHandler<EventRegistrationItemsCreatedEvent>
{
    private readonly ILogger<EventRegistrationItemsCreatedEventHandler> _logger;
    public EventRegistrationItemsCreatedEventHandler(ILogger<EventRegistrationItemsCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(EventRegistrationItemsCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("EventMX.Registration Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
