namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;
    using Types;

    public interface IStudent
    {
        string FirstName { get; }

        Grade Grade { get; }

        string LastName { get; }

        ICollection<IMark> Marks { get; }

        string ListMarks();
    }
}
