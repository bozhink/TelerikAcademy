namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;
    using Types;

    /// <summary>
    /// Defines a student object.
    /// </summary>
    public interface IStudent : IPerson
    {
        /// <summary>
        /// Represents the current grade of the student.
        /// </summary>
        Grade Grade { get; }

        /// <summary>
        /// Represents the collection of marks obtained from the student.
        /// </summary>
        ICollection<IMark> Marks { get; }

        /// <summary>
        /// List the collection of marks as single string message.
        /// </summary>
        /// <returns>The collection of marks as single string message.</returns>
        string ListMarks();
    }
}
