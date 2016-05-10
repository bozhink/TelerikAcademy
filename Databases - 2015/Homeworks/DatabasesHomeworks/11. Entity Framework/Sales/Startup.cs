namespace Sales
{
    using System;
    using System.Linq;
    using NorthwindDBContext;

    public class Startup
    {
        public static void Main()
        {
            const string Region = "ID";
            var startDate = new DateTime(1990, 1, 1);
            var endDate = new DateTime(1996, 12, 31);

            using (var db = new NorthwindEntities())
            {
                var sales = db.Orders
                    .Where(o => o.ShipRegion == Region &&
                                o.OrderDate >= startDate &&
                                o.OrderDate <= endDate)
                    .ToList();

                foreach (var sale in sales)
                {
                    Console.WriteLine("{0} {1}", sale.ShipRegion, sale.OrderDate);
                }
            }
        }
    }
}
