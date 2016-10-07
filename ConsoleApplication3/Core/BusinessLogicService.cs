namespace SchoolSystem.Core
{
    using Contracts;

    // TODO: middleman
    internal class BusinessLogicService
    {
        public void Execute(IReader reader, IWriter writer)
        {
            var engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
