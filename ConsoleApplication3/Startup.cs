namespace SchoolSystem
{
    using SchoolSystem.Core;

    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at least 2 more provider like this one
            var padhana = new ConsoleReader();

            var service = new BusinessLogicService();
            service.Execute(padhana);
        }
    }
}
