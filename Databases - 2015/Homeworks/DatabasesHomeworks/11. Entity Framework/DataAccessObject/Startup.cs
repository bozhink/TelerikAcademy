namespace DataAccessObject
{
    using System;
    using NorthwindDBContext;

    public class Startup
    {
        public static void Main()
        {
            var customer = new Customer
            {
                CustomerID = "00000",
                CompanyName = "X Ltd.",
                ContactName = "Contact Name",
                ContactTitle = "CEO",
                Address = "Some Address",
                City = "Somewhere city",
                PostalCode = "11000",
                Country = "USA",
                Phone = "000-1234567",
                Fax = "000-1234567"
            };

            using (var database = new NorthwindEntities())
            {
                InsertCustomer(database, customer);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                ModifyCustomer(database, customer);

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

                DeleteCustomer(database, customer);
            }
        }

        private static void DeleteCustomer(NorthwindEntities database, Customer customer)
        {
            try
            {
                database.Customers.Remove(customer);
                int affectedRows = database.SaveChanges();

                PrintAffectedRows(affectedRows);
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }

        private static void ModifyCustomer(NorthwindEntities database, Customer customer)
        {
            try
            {
                customer.ContactName += "2";
                int affectedRows = database.SaveChanges();

                PrintAffectedRows(affectedRows);
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }

        private static void InsertCustomer(NorthwindEntities database, Customer customer)
        {
            try
            {
                database.Customers.Add(customer);
                int affectedRows = database.SaveChanges();

                PrintAffectedRows(affectedRows);
            }
            catch (Exception e)
            {
                LogException(e);
            }
        }

        private static void PrintAffectedRows(int affectedRows)
        {
            if (affectedRows == 1)
            {
                Console.WriteLine("({0} row affected)", affectedRows);
            }
            else
            {
                Console.WriteLine("({0} rows affected)", affectedRows);
            }
        }

        private static void LogException(Exception e)
        {
            Console.WriteLine("{0}: {1}", e.GetType(), e.Message);
        }
    }
}
