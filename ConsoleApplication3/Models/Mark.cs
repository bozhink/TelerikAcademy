namespace SchoolSystem.Models
{
    using System;
    using Constants;
    using Contracts;
    using Types;

    public class Mark : IMark
    {
        private float markValue;

        public Mark(Subject subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.markValue;
            }

            set
            {
                if (value < ValidationConstants.MinimalMarkValue || value > ValidationConstants.MaximalMarkValue)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.Value));
                }

                this.markValue = value;
            }
        }

        public Subject Subject { get; private set; }
    }
}
