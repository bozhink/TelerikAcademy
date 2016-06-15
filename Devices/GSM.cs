namespace Devices
{
    using System;

    public class GSM
    {
        private static GSM iphone4S;

        public Battery batteryCharacteristics;
        public decimal price;
        public Display displayCharacteristics;
        public string manufacturer;
        public string model;
        public string owner;

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
        }

        public GSM(string model, string manufacturer, string owner, decimal price, Battery batteryCharacteristics, Display displayCharacteristics)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Owner = owner;
            this.Price = price;
            this.BatteryCharacteristics = batteryCharacteristics;
            this.DisplayCharacteristics = displayCharacteristics;
        }

        public static GSM IPhone4S => iphone4S;

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
