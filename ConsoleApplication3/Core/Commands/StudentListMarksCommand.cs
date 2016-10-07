namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    internal class StudentListMarksCommand : ICommand
    {
        // StudentListMarks [StudentId]
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);

            var student = Engine.Students[studentId];

            return student.ListMarks();
        }
    }
}
