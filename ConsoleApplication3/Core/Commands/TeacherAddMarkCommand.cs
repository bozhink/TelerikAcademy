namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    internal class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[1]);
            var student = Engine.students[studentId];

            var teacherId = int.Parse(parameters[0]);
            var teacher = Engine.teachers[teacherId];

            var markValue = float.Parse(parameters[2]);
            teacher.AddMark(student, markValue);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
