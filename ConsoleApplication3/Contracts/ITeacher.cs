namespace SchoolSystem.Contracts
{
    using Types;

    public interface ITeacher : IPerson
    {
        Subject Subject { get; }

        void AddMark(IStudent student, float value);
    }
}
