namespace ExcelOleDBReader
{
    using System;
    using System.Configuration;
    using System.Data.OleDb;

    /// <summary>
    /// 06. Create an Excel file with 2 columns: name and score.
    ///     Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
    /// </summary>
    public class ExcelOleDBReader
    {
        public static void Main()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["ScoreDb"];

            var connection = new OleDbConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    var command = new OleDbCommand("SELECT * FROM [ScroreSheet$]", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        double score = (double)reader["Score"];

                        Console.WriteLine("Name: {0}\tScore: {1}", name, score);
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
