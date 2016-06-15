namespace Devices
{
    using System;

    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(string model)
        {
            this.Model = model;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
            this.Type = BatteryType.Other;
        }

        public Battery(string model, int hoursIdle, int hoursTalk, BatteryType type)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }

        public BatteryType Type { get; set; }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Model));
                }

                this.model = value;
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.HoursIdle));
                }

                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.HoursTalk));
                }

                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            return $"Battery: {this.Model}: idle: {this.HoursIdle} h, talk: {this.HoursTalk} h.\n";
        }
    }
}
