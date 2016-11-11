namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Framework.Core.Commands.Contracts;
    using SchoolSystem.Framework.Core.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Models.Enums;

    public class CreateTeacherCommand : ICommand
    {
        private readonly ITeacherFactory teacherFactory;
        private readonly ITeacherRepository repository;

        public CreateTeacherCommand(ITeacherFactory teacherFactory, ITeacherRepository repository)
        {
            if (teacherFactory == null)
            {
                throw new ArgumentNullException(nameof(teacherFactory));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.teacherFactory = teacherFactory;
            this.repository = repository;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Count < 3)
            {
                throw new ArgumentException("Three parameters are needed in order: <firstName> <lastName> <subject>", nameof(parameters));
            }

            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject);
            var id = this.repository.Add(teacher);

            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {id} was created.";
        }
    }
}
