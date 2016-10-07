namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    internal class RemoveTeacherCommand : ICommand
    {
        // RemoveTeacher [TeacherId]
        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);

            Engine.Teachers.Remove(teacherId);

            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
