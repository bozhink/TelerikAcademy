namespace Events
{
    using System;
    using Contracts;
    using Wintellect.PowerCollections;

    public class EventHolder : IEventHolder
    {
        private readonly IMessages messages;

        private MultiDictionary<string, IEvent> eventsByTitle;
        private OrderedBag<IEvent> eventsOrderedByDate;

        public EventHolder(IMessages messages)
        {
            if (messages == null)
            {
                throw new ArgumentNullException(nameof(messages));
            }

            this.messages = messages;

            this.eventsByTitle = new MultiDictionary<string, IEvent>(true);
            this.eventsOrderedByDate = new OrderedBag<IEvent>();
        }

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsOrderedByDate.Add(newEvent);
            this.messages.EventAdded();
        }

        public void DeleteEvents(string titleToDelete)
        {
            string titleToLower = titleToDelete.ToLower();

            int numberOfRemovedItems = 0;
            foreach (var eventToRemove in this.eventsByTitle[titleToLower])
            {
                numberOfRemovedItems++;
                this.eventsOrderedByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(titleToLower);
            this.messages.EventDeleted(numberOfRemovedItems);
        }

        public void ListEvents(DateTime date, int count)
        {
            var eventsToShow = this.eventsOrderedByDate
                .RangeFrom(new Event(date, string.Empty, string.Empty), true);

            int showed = 0;
            foreach (var eventToShow in eventsToShow)
            {
                if (showed == count)
                {
                    break;
                }

                this.messages.PrintEvent(eventToShow);

                showed++;
            }

            if (showed == 0)
            {
                this.messages.NoEventsFound();
            }
        }
    }
}
