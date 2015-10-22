namespace CustomersOrdersSql
{
    using System;

    public class ResultantCustomer
    {
        public string CustomerName { get; set; }

        public DateTime OrderYear { get; set; }

        public string ShipCountry { get; set; }

        public override string ToString()
        {
            return $"CustomerName: {this.CustomerName}, OrderYear: {this.OrderYear}, ShipCountry: {this.ShipCountry}";
        }
    }
}