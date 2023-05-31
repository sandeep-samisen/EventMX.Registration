namespace EventMX.Domain.Events.EventItemsEvents;
public class EventRegistrationItemsCompletedEvent : BaseEvent
{
    public EventRegistrationItemsCompletedEvent(EventRegistrationItems eventRegistrationItems)
    {
        EventRegistrationItems = eventRegistrationItems;
    }

    public EventRegistrationItems EventRegistrationItems { get; }
}
