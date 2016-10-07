namespace SchoolSystem.Contracts
{
    using Types;

    /// <summary>
    /// Defines a teacher object.
    /// </summary>
    public interface ITeacher : IPerson
    {
        /// <summary>
        /// Represents the current teaching subject of the teacher.
        /// </summary>
        Subject Subject { get; }

        /// <summary>
        /// Add a mark value for the current teacher’s subject to a student.
        /// </summary>
        /// <param name="student">The recipient (victim) of the mark.</param>
        /// <param name="value">The value of the added mark.</param>
        void AddMark(IStudent student, float value);
    }
}
