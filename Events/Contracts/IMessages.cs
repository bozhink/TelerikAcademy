namespace Events.Contracts
{
    public interface IMessages
    {
        void EventAdded();

        void EventDeleted(int numberOfRemovedItems);

        void NoEventsFound();

        void PrintEvent(IEvent eventToPrint);
    }
}
