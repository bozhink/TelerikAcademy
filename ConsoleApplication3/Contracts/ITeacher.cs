namespace SchoolSystem.Contracts
{
    using Types;

    public interface ITeacher
    {
        string FirstName { get; }

        string LastName { get; }

        Subject Subject { get; }

        void AddMark(IStudent student, float value);
    }
}
