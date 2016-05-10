namespace MultipleDbContexts
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using NorthwindDBContext;

    public class Startup
    {
        private const int NumberOfGeneratedCustomers = 10000;
        private const int MaximumNumberOfIterations = 100;

        public static void Main()
        {
            var changes1 = ChangeDbAsync(1);
            var changes2 = ChangeDbAsync(2);
            Console.WriteLine(changes1.Result);
            Console.WriteLine(changes2.Result);
        }

        private static async Task<int> ChangeDbAsync(int index)
        {
            var db = new NorthwindEntities();
            HashSet<string> customerIds = GetCustomerIds(db);

            for (int i = 0; i < NumberOfGeneratedCustomers; i++)
            {
                for (int j = 0; j < MaximumNumberOfIterations; j++)
                {
                    try
                    {
                        string seed = Guid.NewGuid().ToString();
                        var customer = new Customer()
                        {
                            CustomerID = seed.Substring(0, 5),
                            CompanyName = "Company name " + seed.Substring(5, 20)
                        };

                        if (customerIds.Contains(customer.CustomerID.ToLower()))
                        {
                            continue;
                        }

                        db.Customers.Add(customer);

                        break;
                    }
                    catch (SqlException e)
                    {
                        if ((MaximumNumberOfIterations - j) < 2)
                        {
                            throw new ApplicationException("SqlException in db.Customers.Add", e);
                        }
                    }
                }

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new NorthwindEntities();
                    customerIds = GetCustomerIds(db);
                }
            }

            db.SaveChanges();
            db.Dispose();

            Console.WriteLine("Thread {0}", index);

            return await Task.Run(() => index);
        }

        private static HashSet<string> GetCustomerIds(NorthwindEntities db)
        {
            var result = new HashSet<string>(db.Customers
                               .Select(c => c.CustomerID)
                               .ToList()
                               .Select(id => id.ToLower()));
            return result;
        }
    }
}
