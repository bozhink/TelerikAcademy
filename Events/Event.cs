namespace Events
{
    using System;
    using System.Text;
    using Constants;
    using Contracts;

    public class Event : IEvent
    {
        private DateTime date;
        private string location;
        private string title;

        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            private set
            {
                this.date = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Location));
                }

                this.location = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Title));
                }

                this.title = value;
            }
        }

        public int CompareTo(object obj)
        {
            var objAsEvent = obj as Event;

            int comparedByDate = this.Date.CompareTo(objAsEvent.Date);
            if (comparedByDate == 0)
            {
                int comparedByTitle = this.Title.CompareTo(objAsEvent.Title);
                if (comparedByTitle == 0)
                {
                    int comparedByLocation = this.Location.CompareTo(objAsEvent.Location);
                    return comparedByLocation;
                }
                else
                {
                    return comparedByTitle;
                }
            }
            else
            {
                return comparedByDate;
            }
        }

        public override string ToString()
        {
            var resultStringBuilder = new StringBuilder();
            resultStringBuilder.Append(this.Date.ToString(FormatConstants.DefaultDateTimeFormat));

            resultStringBuilder.Append(FormatConstants.DefaultSeparator + this.Title);
            if (!string.IsNullOrEmpty(this.Location))
            {
                resultStringBuilder.Append(FormatConstants.DefaultSeparator + this.Location);
            }

            return resultStringBuilder.ToString();
        }
    }
}
