namespace Events
{
    using System;
    using Constants;
    using Contracts;

    public class Startup : IStartup
    {
        private readonly IEventHolder events;

        public Startup(IEventHolder events)
        {
            if (events == null)
            {
                throw new ArgumentNullException(nameof(events));
            }

            this.events = events;
        }

        public void Run()
        {
            while (this.ExecuteNextCommand())
            {
            }
        }

        private void AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            this.GetParameters(command, nameof(IEventHolder.AddEvent), out date, out title, out location);

            this.events.AddEvent(date, title, location);
        }

        private void DeleteEvents(string command)
        {
            string title = command.Substring(nameof(IEventHolder.DeleteEvents).Length + 1);
            this.events.DeleteEvents(title);
        }

        private bool ExecuteNextCommand()
        {
            string command = Console.ReadLine();
            if (command[0] == 'A')
            {
                this.AddEvent(command);
                return true;
            }

            if (command[0] == 'D')
            {
                this.DeleteEvents(command);
                return true;
            }

            if (command[0] == 'L')
            {
                this.ListEvents(command);
                return true;
            }

            if (command[0] == 'E')
            {
                return false;
            }

            return false;
        }

        private DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }

        private void GetParameters(string commandForExecution, string commandType, out DateTime dateAndTime, out string eventTitle, out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf(ContentConstants.PipeSign);

            int lastPipeIndex = commandForExecution.LastIndexOf(ContentConstants.PipeSign);
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private void ListEvents(string command)
        {
            int pipeIndex = command.IndexOf(ContentConstants.PipeSign);
            DateTime date = this.GetDate(command, nameof(IEventHolder.ListEvents));
            string countString = command.Substring(pipeIndex + 1);

            int count = int.Parse(countString);
            this.events.ListEvents(date, count);
        }
    }
}
