namespace SchoolSystem.Models
{
    using System;
    using Constants;
    using Contracts;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.FirstName));
                }

                if (value.Length < ValidationConstants.MinimalNameLength || value.Length > ValidationConstants.MaximalNameLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.FirstName));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.LastName));
                }

                if (value.Length < ValidationConstants.MinimalNameLength || value.Length > ValidationConstants.MaximalNameLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.LastName));
                }

                this.lastName = value;
            }
        }
    }
}
