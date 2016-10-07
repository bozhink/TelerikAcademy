namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;
    using Types;

    internal class CreateStudentCommand : ICommand
    {
        private static readonly IdGenerator IdGenerator;

        static CreateStudentCommand()
        {
            IdGenerator = new IdGenerator();
        }

        // CreateStudent [FirstName] [LastName] [Grade]
        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = new Student(firstName, lastName, grade);

            var id = IdGenerator.Next();
            Engine.Students.Add(id, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }
    }
}
