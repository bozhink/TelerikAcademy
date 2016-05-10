namespace NorthwindTwin
{
    using System;
    using NorthwindDBContext;

    public class Startup
    {
        public static void Main()
        {
            var db = new NorthwindEntities();

            bool isCreated = db.Database.CreateIfNotExists();

            Console.WriteLine(isCreated);
        }
    }
}
