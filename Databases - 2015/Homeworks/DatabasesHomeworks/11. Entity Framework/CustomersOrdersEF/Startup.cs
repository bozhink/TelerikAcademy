namespace Sales
{
    using System;
    using System.Linq;
    using NorthwindDBContext;

    public class Startup
    {
        private const int YearOfOrder = 1997;
        private const string ShipCountry = "Canada";

        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers
                    .Join(
                        db.Orders,
                        c => c.CustomerID,
                        o => o.CustomerID,
                        (c, o) => new
                        {
                            CustomerName = c.ContactName,
                            OrderYear = o.OrderDate.Value.Year,
                            ShipCountry = o.ShipCountry
                        })
                    .Where(c => c.OrderYear == Startup.YearOfOrder && c.ShipCountry == Startup.ShipCountry)
                    .ToList();

                customers.ForEach(Console.WriteLine);
            }
        }
    }
}
