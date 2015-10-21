namespace NorthwindCategoriesImages
{
    using System;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;

    public class NorthwindCategoriesImages
    {
        private const int OleMetaFilePictStartPosition = 78;

        public static void Main(string[] args)
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["NorthwindDB"];

            var connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SELECT [CategoryId] AS [ID], [Picture] AS [PIC] FROM [Northwind].[dbo].[Categories]", connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["ID"];
                            byte[] picture = (byte[])reader["PIC"];

                            string filePath = string.Format("category-{0}.jpg", id.ToString("d5"));

                            using (var stream = new MemoryStream(picture, OleMetaFilePictStartPosition, picture.Length - OleMetaFilePictStartPosition))
                            {
                                Image image = Image.FromStream(stream);
                                image.Save(filePath, ImageFormat.Jpeg);
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