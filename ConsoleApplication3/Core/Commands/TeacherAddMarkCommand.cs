namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    internal class TeacherAddMarkCommand : ICommand
    {
        // TeacherAddMark [TeacherId] [StudentId] [Mark]
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var teacher = Engine.Teachers[teacherId];

            var studentId = int.Parse(parameters[1]);
            var student = Engine.Students[studentId];

            var markValue = float.Parse(parameters[2]);
            teacher.AddMark(student, markValue);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
