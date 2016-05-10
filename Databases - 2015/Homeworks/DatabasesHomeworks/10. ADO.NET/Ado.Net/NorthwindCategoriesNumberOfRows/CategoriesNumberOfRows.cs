namespace NorthwindCategoriesNumberOfRows
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// 01. Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.
    /// </summary>
    public class CategoriesNumberOfRows
    {
        public static void Main()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"];

            var connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Categories]", connection);

                    int numberOfRows = (int)command.ExecuteScalar();

                    Console.WriteLine("Number of rows in [Northwind].[dbo].[Categories] = {0}", numberOfRows);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}