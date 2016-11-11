namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Framework.Core.Commands.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;

    public class RemoveStudentCommand : ICommand
    {
        private readonly IStudentRepository repository;

        public RemoveStudentCommand(IStudentRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.repository = repository;
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Count < 1)
            {
                throw new ArgumentException("One parameter is needed: <studentId>", nameof(parameters));
            }

            var studentId = int.Parse(parameters[0]);

            if (this.repository.GetById(studentId) == null)
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.repository.Remove(studentId);
            return $"Student with ID {studentId} was sucessfully removed.";
        }
    }
}
