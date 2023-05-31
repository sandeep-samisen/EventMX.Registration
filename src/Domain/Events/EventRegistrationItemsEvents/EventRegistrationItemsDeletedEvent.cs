namespace EventMX.Domain.Events.EventItemsEvents;
public class EventRegistrationItemsDeletedEvent : BaseEvent
{
    public EventRegistrationItemsDeletedEvent(EventRegistrationItems eventRegistrationItems)
    {
        EventRegistrationItems = eventRegistrationItems;
    }

    public EventRegistrationItems EventRegistrationItems { get; }
}
