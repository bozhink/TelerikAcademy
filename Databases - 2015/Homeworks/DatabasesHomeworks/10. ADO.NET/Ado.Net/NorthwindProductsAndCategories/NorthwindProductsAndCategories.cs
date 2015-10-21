namespace NorthwindProductsAndCategories
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    public class NorthwindProductsAndCategories
    {
        /// <summary>
        /// 03. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
        /// </summary>
        public static void Main()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"];

            var connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT c.[CategoryName] AS [CategoryName], p.[ProductName] AS [ProductName] FROM [Northwind].[dbo].[Products] p JOIN [Northwind].[dbo].[Categories] c ON p.[CategoryID] = c.[CategoryID] ORDER BY c.[CategoryName]", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoryName = (string)reader["CategoryName"];
                            string productName = (string)reader["ProductName"];
                            Console.WriteLine("Category Name = {0}\tProduct Name = {1}", categoryName, productName);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}