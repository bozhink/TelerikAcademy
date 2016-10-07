namespace SchoolSystem.Core
{
    internal class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider consoleReaderProvider)
        {
            var engine = new Engine(consoleReaderProvider);
            engine.BrumBrum();
        }
    }
}
