namespace NorthwindManualEscape
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// 08. Write a program that reads a string from the console and finds all products that contain this string.
    ///     Ensure you handle correctly characters like ', %, ", \ and _.
    /// </summary>
    public class NorthwindManualEscape
    {
        public static void Main(string[] args)
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"];

            var connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Enter product name to search or 'bye' to exit: ");
                        var seachWords = Console.ReadLine();
                        if (seachWords.ToLower() == "bye")
                        {
                            break;
                        }

                        seachWords = Regex.Replace(seachWords, @"(?=[%""&_\\])", @"\");
                        ////Console.WriteLine(seachWords);

                        SqlCommand command = new SqlCommand("SELECT [ProductName] FROM [Northwind].[dbo].[Products] WHERE [ProductName] LIKE CONCAT('%', @name, '%')", connection);
                        command.Parameters.AddWithValue("@name", seachWords);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string productName = (string)reader["ProductName"];
                                Console.WriteLine("{0} -> {1}", seachWords, productName);
                            }
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
