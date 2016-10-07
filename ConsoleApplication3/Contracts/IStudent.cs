namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;

    public interface IStudent
    {
        string FirstName { get; }

        Grade Grade { get; }

        string LastName { get; }

        ICollection<IMark> Marks { get; }

        string ListMarks();
    }
}
