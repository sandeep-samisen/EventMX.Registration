namespace EventMX.Registration.Domain.Events.EventRegistrationItemsEvents;
public class EventRegistrationItemsCreatedEvent : BaseEvent
{
    public EventRegistrationItemsCreatedEvent(EventRegistrationItems eventRegistrationItems)
    {
        EventRegistrationItems = eventRegistrationItems;
    }

    public EventRegistrationItems EventRegistrationItems { get; set; }
}
