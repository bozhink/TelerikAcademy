namespace SchoolSystem.Framework.Core.Contracts
{
    using SchoolSystem.Framework.Models.Contracts;
    using SchoolSystem.Framework.Models.Enums;

    public interface ITeacherFactory
    {
        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);
    }
}
