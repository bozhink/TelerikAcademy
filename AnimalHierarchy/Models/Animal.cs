namespace AnimalHierarchy.Models
{
    using System;
    using Contracts;

    public abstract class Animal : ISound
    {
        private string name;
        private decimal age;

        public Animal(string name, decimal age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public virtual string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Name));
                }

                this.name = value;
            }
        }

        public virtual decimal Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentException(nameof(this.Age));
                }

                if (value > 1000m)
                {
                    throw new ArgumentException("Are you kidding me?", nameof(this.Age));
                }

                this.age = value;
            }
        }

        public virtual Sex Sex { get; private set; }

        public abstract string ProduceSound();
    }
}
