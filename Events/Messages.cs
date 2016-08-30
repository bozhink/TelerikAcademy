namespace Events
{
    using System;
    using Contracts;

    public class Messages : IMessages
    {
        private readonly ILogger logger;

        public Messages(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            this.logger = logger;
        }

        public void EventAdded()
        {
            this.logger.Append("Event added\n");
        }

        public void EventDeleted(int numberOfRemovedItems)
        {
            if (numberOfRemovedItems == 0)
            {
                this.NoEventsFound();
            }
            else
            {
                this.logger.AppendFormat("{0} events deleted\n", numberOfRemovedItems);
            }
        }

        public void NoEventsFound()
        {
            this.logger.Append("No events found\n");
        }

        public void PrintEvent(IEvent eventToPrint)
        {
            if (eventToPrint != null)
            {
                this.logger.Append(eventToPrint + "\n");
            }
        }
    }
}
