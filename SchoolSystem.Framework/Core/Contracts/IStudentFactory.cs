namespace SchoolSystem.Framework.Core.Contracts
{
    using SchoolSystem.Framework.Models.Contracts;
    using SchoolSystem.Framework.Models.Enums;

    public interface IStudentFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);
    }
}
