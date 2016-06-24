namespace StudentsAndWorkers.Models
{
    using System;

    public class Worker : Human
    {
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName, decimal workHoursPerDay, decimal weekSalary)
            : this(firstName, lastName, workHoursPerDay)
        {
            this.WeekSalary = weekSalary;
        }

        /// <summary>
        /// Week salary can be 0 or negative :(
        /// So here we don't need such validation.
        /// </summary>
        public decimal WeekSalary { get; set; }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (24m < value || value <= 0m)
                {
                    throw new ArgumentException(nameof(this.WorkHoursPerDay));
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (7.0m * this.WorkHoursPerDay);
        }

        public override string ToString()
        {
            return base.ToString() + $": ${this.WeekSalary} / (7 * {this.WorkHoursPerDay}) = ${this.MoneyPerHour()}";
        }
    }
}
