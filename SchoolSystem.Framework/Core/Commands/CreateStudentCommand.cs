using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Data.Contracts.Repositories;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private readonly IStudentFactory studentFactory;
        private readonly IStudentRepository repository;

        public CreateStudentCommand(IStudentFactory studentFactory, IStudentRepository repository)
        {
            if (studentFactory == null)
            {
                throw new ArgumentNullException(nameof(studentFactory));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.studentFactory = studentFactory;
            this.repository = repository;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);
            var id = this.repository.Add(student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {id} was created.";
        }
    }
}
