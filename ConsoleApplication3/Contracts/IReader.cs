namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Defines general reader of input data.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads input command string.
        /// </summary>
        /// <returns>The passed command string.</returns>
        string ReadLine();
    }
}
