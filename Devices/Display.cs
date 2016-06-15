namespace Devices
{
    using System;

    public class Display
    {
        private string size;
        private ulong numberOfColors;

        public Display()
        {
            this.size = null;
            this.numberOfColors = 0;
        }

        public Display(string size, ulong numberOfColors)
        {
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        public string Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.Size));
                }

                this.size = value;
            }
        }

        public ulong NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException(nameof(this.NumberOfColors));
                }

                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            return $"Display: Size: {this.Size}, number of colors: {this.NumberOfColors}.\n";
        }
    }
}
