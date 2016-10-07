namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string FirstName { get; }

        Grade Grade { get; }

        string LastName { get; }

        ICollection<Mark> Marks { get; }

        string ListMarks();
    }
}
