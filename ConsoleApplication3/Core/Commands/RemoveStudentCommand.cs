namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    internal class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            Engine.students.Remove(studentId);

            return $"Student with ID {studentId} was successfully removed.";
        }
    }
}
