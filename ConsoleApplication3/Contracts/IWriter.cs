namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Defines general writer of output data.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Exports output message.
        /// </summary>
        /// <param name="message">Output message to be exported.</param>
        void WriteLine(string message);
    }
}
