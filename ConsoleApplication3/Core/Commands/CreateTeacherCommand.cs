namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Types;

    internal class CreateTeacherCommand : ICommand
    {
        // CreateTeacher [FirstName] [LastName] [SubjectId]
        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = new Teacher(firstName, lastName, subject);

            var id = IdGenerator.Next();
            Engine.Teachers.Add(id, teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
