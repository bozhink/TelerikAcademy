namespace SchoolSystem.Contracts
{
    public interface ITeacher
    {
        string FirstName { get; }

        string LastName { get; }

        Subject Subject { get; }

        void AddMark(Student student, float value);
    }
}
