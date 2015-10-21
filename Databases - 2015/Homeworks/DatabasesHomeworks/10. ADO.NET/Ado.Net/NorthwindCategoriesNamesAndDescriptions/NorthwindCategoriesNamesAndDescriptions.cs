namespace NorthwindCategoriesNamesAndDescriptions
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// 02. Write a program that retrieves the name and description of all categories in the Northwind DB.
    /// </summary>
    public class NorthwindCategoriesNamesAndDescriptions
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
                    SqlCommand command = new SqlCommand("SELECT [CategoryName] AS [Name], [Description] AS [Description] FROM [Northwind].[dbo].[Categories]", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader["Name"];
                            string description = (string)reader["Description"];
                            Console.WriteLine("Name = {0},\n\tDescrition = {1}", name, description);
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