namespace Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CallsManager;

    public class GSM
    {
        private static GSM iphone4S;

        private readonly ICollection<Call> callHistory;

        private Battery batteryCharacteristics;
        private decimal price;
        private Display displayCharacteristics;
        private string manufacturer;
        private string model;
        private string owner;

        static GSM()
        {
            iphone4S = new GSM("iPhone 4S", "Apple", "Pesho", 500.0m, new Battery("IPhone4S Battery", 48, 24, BatteryType.LiIon), new Display("4.5in", 16000000));
        }

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.batteryCharacteristics = null;
            this.price = 0.0m;
            this.displayCharacteristics = null;
            this.owner = null;
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, string owner, decimal price, Battery batteryCharacteristics, Display displayCharacteristics)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Price = price;
            this.BatteryCharacteristics = batteryCharacteristics;
            this.DisplayCharacteristics = displayCharacteristics;
            this.callHistory = new List<Call>();
        }

        public static GSM IPhone4S => iphone4S;

        public ICollection<Call> CallHistory => this.callHistory;

        public Battery BatteryCharacteristics
        {
            get
            {
                return this.batteryCharacteristics;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.BatteryCharacteristics));
                }

                this.batteryCharacteristics = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentException(nameof(this.Price));
                }

                this.price = value;
            }
        }

        public Display DisplayCharacteristics
        {
            get
            {
                return this.displayCharacteristics;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.DisplayCharacteristics));
                }

                this.displayCharacteristics = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Manufacturer));
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Model));
                }

                this.model = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.Owner));
                }

                this.owner = value;
            }
        }

        public void AddCall(Call call)
        {
            if (call == null)
            {
                throw new ArgumentNullException(nameof(call));
            }

            this.CallHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            if (call == null)
            {
                throw new ArgumentNullException(nameof(call));
            }

            this.CallHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal TotalPriceOfCalls(decimal pricePerMinute)
        {
            decimal pricePerSecond = pricePerMinute / 60.0m;

            return this.CallHistory
                .Select(c => c.DurationInSeconds * pricePerSecond)
                .Sum();
        }

        public string GetInformation()
        {
            return $"{this.Manufacturer} / {this.Model} / {this.Owner ?? string.Empty}\n{this.BatteryCharacteristics?.ToString() ?? string.Empty}{this.DisplayCharacteristics?.ToString() ?? string.Empty}\n\tPrice: {this.Price}";
        }

        public override string ToString()
        {
            return this.GetInformation();
        }
    }
}
