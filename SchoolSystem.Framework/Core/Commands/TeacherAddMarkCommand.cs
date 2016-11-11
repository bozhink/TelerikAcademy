using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly IStudentRepository studentRepository;

        public TeacherAddMarkCommand(ITeacherRepository teacherRepository, IStudentRepository studentRepository)
        {
            if (teacherRepository == null)
            {
                throw new ArgumentNullException(nameof(teacherRepository));
            }

            if (studentRepository == null)
            {
                throw new ArgumentNullException(nameof(studentRepository));
            }

            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.studentRepository.GetById(studentId);
            var teacher = this.teacherRepository.GetById(teacherId);

            teacher.AddMark(student, mark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
