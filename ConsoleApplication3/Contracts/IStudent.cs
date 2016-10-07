namespace SchoolSystem.Contracts
{
    using System.Collections.Generic;
    using Types;

    public interface IStudent : IPerson
    {
        Grade Grade { get; }

        ICollection<IMark> Marks { get; }

        string ListMarks();
    }
}
