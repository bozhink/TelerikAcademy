namespace SchoolSystem.Contracts
{
    using Types;

    public interface IMark
    {
        Subject Subject { get; }
        float Value { get; }
    }
}
