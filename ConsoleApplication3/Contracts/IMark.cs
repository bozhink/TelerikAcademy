namespace SchoolSystem.Contracts
{
    using Types;

    /// <summary>
    /// Defines a mark object.
    /// </summary>
    public interface IMark
    {
        /// <summary>
        /// Represents the subject of the mark.
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Represents the value of the mark.
        /// </summary>
        float Value { get; }
    }
}
