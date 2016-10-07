namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Defines a person object.
    /// </summary>
    public interface IPerson
    {
        /// <summary>
        /// Represents the first name of a person.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// Represents the last name of a person.
        /// </summary>
        string LastName { get; }
    }
}
