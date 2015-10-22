namespace EmployeeTerritories
{
    using System;
    using System.Linq;
    using NorthwindDBContext;

    public class Startup
    {
        public static void Main()
        {
            using (var db = new NorthwindEntities())
            {
                foreach (var employee in db.Employees.Include("Territories"))
                {
                    Console.WriteLine("{0} -> {1}", employee.FirstName, string.Join(", ", employee.TerritoryProperty.Select(t => t.TerritoryDescription.Trim())));
                }
            }
        }
    }
}
