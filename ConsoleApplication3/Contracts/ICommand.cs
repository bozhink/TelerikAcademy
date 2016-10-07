namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines general command to be executed.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Runs the command execution.
        /// </summary>
        /// <param name="parameters">Parameters to provide needed execution data.</param>
        /// <returns>Execution validation message.</returns>
        string Execute(IList<string> parameters);
    }
}
