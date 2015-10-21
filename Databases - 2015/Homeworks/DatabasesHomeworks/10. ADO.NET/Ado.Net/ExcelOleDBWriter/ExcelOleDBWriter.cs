namespace ExcelOleDBWriter
{
    using System;
    using System.Configuration;
    using System.Data.OleDb;

    /// <summary>
    /// 07. Implement appending new rows to the Excel file.
    /// </summary>
    public class ExcelOleDBWriter
    {
        // After execution see the Score.xlsx in the output bin directory.
        public static void Main()
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["ScoreDb"];

            var connection = new OleDbConnection(connectionString.ConnectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    var command = new OleDbCommand("INSERT INTO [ScroreSheet$] (Name, Score) VALUES (@name, @score)", connection);

                    command.Parameters.AddWithValue("@name", "New name");
                    command.Parameters.AddWithValue("@score", 31.5);

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
