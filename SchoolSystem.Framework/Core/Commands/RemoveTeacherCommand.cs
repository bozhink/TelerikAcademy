namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Framework.Core.Commands.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;

    public class RemoveTeacherCommand : ICommand
    {
        private readonly ITeacherRepository repository;

        public RemoveTeacherCommand(ITeacherRepository repository)
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
                throw new ArgumentException("One parameter is needed: <teacherId>", nameof(parameters));
            }

            var teacherId = int.Parse(parameters[0]);

            if (this.repository.GetById(teacherId) == null)
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }

            this.repository.Remove(teacherId);
            return $"Teacher with ID {teacherId} was sucessfully removed.";
        }
    }
}
