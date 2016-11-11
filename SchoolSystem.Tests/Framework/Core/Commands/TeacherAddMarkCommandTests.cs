namespace SchoolSystem.Tests.Framework.Core.Commands
{
    using System;
    using System.Linq;
    using Helpers;
    using Moq;
    using NUnit.Framework;
    using SchoolSystem.Framework.Core.Commands;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Models.Contracts;

    [TestFixture(TestOf = typeof(TeacherAddMarkCommand))]
    public class TeacherAddMarkCommandTests
    {
        private const string TeacherRepositoryFieldName = "teacherRepository";
        private const string StudentRepositoryFieldName = "studentRepository";
        private const string ParametersParameterName = "parameters";

        [Test]
        public void TeacherAddMarkCommand_WithValidParametersInDefaultConstructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var teacherRepositoryMock = new Mock<ITeacherRepository>();
            var studentRepositoryMock = new Mock<IStudentRepository>();

            // Act
            var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, studentRepositoryMock.Object);

            // Assert
            Assert.IsNotNull(command);

            var teacherRepository = PrivateField.GetInstanceField<TeacherAddMarkCommand>(command, TeacherRepositoryFieldName);
            Assert.AreSame(teacherRepositoryMock.Object, teacherRepository);

            var studentRepository = PrivateField.GetInstanceField<TeacherAddMarkCommand>(command, StudentRepositoryFieldName);
            Assert.AreSame(studentRepositoryMock.Object, studentRepository);
        }

        [Test]
        public void TeacherAddMarkCommand_WithNullTeacherRepositoryInDefaultConstructor_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var studentRepositoryMock = new Mock<IStudentRepository>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var command = new TeacherAddMarkCommand(null, studentRepositoryMock.Object);
            });

            Assert.AreEqual(exception.ParamName, TeacherRepositoryFieldName);
        }

        [Test]
        public void TeacherAddMarkCommand_WithNullStudentRepositoryInDefaultConstructor_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var teacherRepositoryMock = new Mock<ITeacherRepository>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, null);
            });

            Assert.AreEqual(exception.ParamName, StudentRepositoryFieldName);
        }

        [Test]
        public void TeacherAddMarkCommand_ExecuteWithNullParameters_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var teacherRepositoryMock = new Mock<ITeacherRepository>();
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, studentRepositoryMock.Object);

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                command.Execute(null);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);
            teacherRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            studentRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void TeacherAddMarkCommand_ExecuteWithNotEnoughParameters_ShouldThorwArgumentExceptionWithCorrectParamName()
        {
            // Arrange
            var teacherRepositoryMock = new Mock<ITeacherRepository>();
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, studentRepositoryMock.Object);

            var parameters = new string[] { "Stamat" }.ToList();

            // Act + Assert
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                command.Execute(parameters);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);
            teacherRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            studentRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
        }

        [TestCase("Pesho 10 2.55")]
        [TestCase("10 Pesho 2.55")]
        [TestCase("10 21.2 2.55")]
        [TestCase("3.14 10 2.55")]
        [TestCase("10 15 Failed")]
        public void TeacherAddMarkCommand_ExecuteWithMalformedNumberParameters_ShouldThorwFormatException(string parametersString)
        {
            // Arrange
            var teacherRepositoryMock = new Mock<ITeacherRepository>();
            var studentRepositoryMock = new Mock<IStudentRepository>();
            var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, studentRepositoryMock.Object);

            var parameters = parametersString.Split(' ').ToList();

            // Act + Assert
            var exception = Assert.Throws<FormatException>(() =>
            {
                command.Execute(parameters);
            });

            teacherRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            studentRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
        }

        [TestCase("1 2 3")]
        [TestCase("10 12 3.14")]
        public void TeacherAddMarkCommand_ExecuteWithValidParameters_ShouldWork(string parametersString)
        {
            // Arrange
            var parameters = parametersString.Split(' ').ToList();
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var teacherMock = new Mock<ITeacher>();

            var studentMock = new Mock<IStudent>();

            var teacherRepositoryMock = new Mock<ITeacherRepository>();
            teacherRepositoryMock.Setup(r => r.GetById(teacherId))
                .Returns(teacherMock.Object);

            var studentRepositoryMock = new Mock<IStudentRepository>();
            studentRepositoryMock.Setup(r => r.GetById(studentId))
                .Returns(studentMock.Object);

            var command = new TeacherAddMarkCommand(teacherRepositoryMock.Object, studentRepositoryMock.Object);

            // Act
            var message = command.Execute(parameters);

            // Assert
            teacherRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
            teacherRepositoryMock.Verify(r => r.GetById(teacherId), Times.Once);

            studentRepositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Once);
            studentRepositoryMock.Verify(r => r.GetById(studentId), Times.Once);

            teacherMock.Verify(t => t.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()), Times.Once);
            teacherMock.Verify(t => t.AddMark(studentMock.Object, mark), Times.Once);
        }
    }
}
