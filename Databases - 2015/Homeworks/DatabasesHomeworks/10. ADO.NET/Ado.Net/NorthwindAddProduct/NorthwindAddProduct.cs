namespace NorthwindAddProduct
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;

    /// <summary>
    /// 04. Write a method that adds a new product in the products table in the Northwind database. Use a parameterized SQL command.
    /// </summary>
    public class NorthwindAddProduct
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
                    SqlCommand command = new SqlCommand("INSERT INTO [Northwind].[dbo].[Products]([ProductName],[SupplierID],[CategoryID],[QuantityPerUnit],[UnitPrice],[UnitsInStock],[UnitsOnOrder],[ReorderLevel],[Discontinued]) VALUES (@productName, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)", connection);

                    command.Parameters.AddWithValue("@productName", "Chai100");
                    command.Parameters.AddWithValue("@supplierID", 1);
                    command.Parameters.AddWithValue("@categoryID", 1);
                    command.Parameters.AddWithValue("@quantityPerUnit", "10 boxes x 20 bags");
                    command.Parameters.AddWithValue("@unitPrice", 18.00M);
                    command.Parameters.AddWithValue("@unitsInStock", 39);
                    command.Parameters.AddWithValue("@unitsOnOrder", 0);
                    command.Parameters.AddWithValue("@reorderLevel", 10);
                    command.Parameters.AddWithValue("@discontinued", 0);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}