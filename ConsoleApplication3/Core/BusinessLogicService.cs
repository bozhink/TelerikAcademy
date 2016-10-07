namespace SchoolSystem.Core
{
    internal class BusinessLogicService
    {
        public void Execute(ConsoleReader consoleReaderProvider)
        {
            var engine = new Engine(consoleReaderProvider);
            engine.BrumBrum();
        }
    }
}
