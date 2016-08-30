namespace Events
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var logger = new Logger();

            var startup = new Startup(new EventHolder(new Messages(logger)));
            startup.Run();
            Console.WriteLine(logger);
        }
    }
}
