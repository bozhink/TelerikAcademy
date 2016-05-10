namespace CustomersOrdersSql
{
    using System;
    using System.Data.SqlClient;
    using NorthwindDBContext;

    public class Startup
    {
        private const string QueryString =
@"SELECT c.[ContactName] AS [CustomerName],
       o.[OrderDate] AS[Order Year],
       o.[ShipCountry]
        AS[ShipCountry]
FROM[Northwind].[dbo].[Customers]
        c
JOIN[Northwind].[dbo].[Orders]
        o
ON c.[CustomerID] = o.[CustomerID]
WHERE YEAR(o.[OrderDate]) = @year AND o.[ShipCountry] = @shipCountry";

        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Database.SqlQuery<ResultantCustomer>(QueryString, new SqlParameter("year", 1997), new SqlParameter("shipCountry", "Canada"));

                customers.ForEachAsync(Console.WriteLine).Wait();
            }
        }
    }
}