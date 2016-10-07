namespace SchoolSystem
{
    public class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider consoleReaderProvider)
        {
            var engine = new Engine(consoleReaderProvider);
            engine.BrumBrum();
        }
    }
}
