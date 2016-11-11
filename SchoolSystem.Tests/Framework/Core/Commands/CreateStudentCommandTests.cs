namespace SchoolSystem.Tests.Framework.Core.Commands
{
    using System;
    using System.Linq;
    using Helpers;
    using Moq;
    using NUnit.Framework;
    using SchoolSystem.Framework.Core.Commands;
    using SchoolSystem.Framework.Core.Contracts;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Models.Contracts;
    using SchoolSystem.Framework.Models.Enums;

    [TestFixture(TestOf = typeof(CreateStudentCommand))]
    public class CreateStudentCommandTests
    {
        private const string StudentFactoryFieldName = "studentFactory";
        private const string RepositoryFieldName = "repository";
        private const string ParametersParameterName = "parameters";

        [Test]
        public void CreateStudentCommand_WithValidParametersInDefaultConstructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var studentFactoryMock = new Mock<IStudentFactory>();
            var repositoryMock = new Mock<IStudentRepository>();

            // Act
            var command = new CreateStudentCommand(studentFactoryMock.Object, repositoryMock.Object);

            // Assert
            Assert.IsNotNull(command);

            var studentFactory = PrivateField.GetInstanceField<CreateStudentCommand>(command, StudentFactoryFieldName);
            Assert.AreSame(studentFactoryMock.Object, studentFactory);

            var repository = PrivateField.GetInstanceField<CreateStudentCommand>(command, RepositoryFieldName);
            Assert.AreSame(repositoryMock.Object, repository);
        }

        [Test]
        public void CreateStudentCommand_WithNullStudentFactoryInDefaultConstructor_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var repositoryMock = new Mock<IStudentRepository>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var command = new CreateStudentCommand(null, repositoryMock.Object);
            });

            Assert.AreEqual(exception.ParamName, StudentFactoryFieldName);
        }

        [Test]
        public void CreateStudentCommand_WithNullRepositoryInDefaultConstructor_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var studentFactoryMock = new Mock<IStudentFactory>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var command = new CreateStudentCommand(studentFactoryMock.Object, null);
            });

            Assert.AreEqual(exception.ParamName, RepositoryFieldName);
        }

        [Test]
        public void CreateStudentCommand_ExecuteWithNullParameters_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var studentFactoryMock = new Mock<IStudentFactory>();
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new CreateStudentCommand(studentFactoryMock.Object, repositoryMock.Object);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                command.Execute(null);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);

            studentFactoryMock.Verify(f => f.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()), Times.Never);

            repositoryMock.Verify(r => r.Add(It.IsAny<IStudent>()), Times.Never);
        }

        [Test]
        public void CreateStudentCommand_ExecuteWithNotEnoughParameters_ShouldThorwArgumentExceptionWithCorrectParamName()
        {
            // Arrange
            var studentFactoryMock = new Mock<IStudentFactory>();
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new CreateStudentCommand(studentFactoryMock.Object, repositoryMock.Object);

            var parameters = new string[] { "Stamat" }.ToList();

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                command.Execute(parameters);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);

            studentFactoryMock.Verify(f => f.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()), Times.Never);

            repositoryMock.Verify(r => r.Add(It.IsAny<IStudent>()), Times.Never);
        }

        [Test]
        public void CreateStudentCommand_ExecuteWithInvalidGradeInParameters_ShouldThorwFormatException()
        {
            // Arrange
            var studentFactoryMock = new Mock<IStudentFactory>();
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new CreateStudentCommand(studentFactoryMock.Object, repositoryMock.Object);

            var parameters = "Izpit bez Pesho ne moze da mine.".Split(' ').ToList();

            // Act
            var exception = Assert.Throws<FormatException>(() =>
            {
                command.Execute(parameters);
            });

            studentFactoryMock.Verify(f => f.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()), Times.Never);

            repositoryMock.Verify(r => r.Add(It.IsAny<IStudent>()), Times.Never);
        }

        [Test]
        public void CreateStudentCommand_ExecuteWithValidParameters_ShouldWork()
        {
            // Arrange
            var parameters = "Pesho Petrov 10".Split(' ').ToList();

            var studentMock = new Mock<IStudent>();

            var studentFactoryMock = new Mock<IStudentFactory>();
            studentFactoryMock.Setup(s => s.CreateStudent(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])))
                .Returns(studentMock.Object);

            var repositoryMock = new Mock<IStudentRepository>();
            var command = new CreateStudentCommand(studentFactoryMock.Object, repositoryMock.Object);

            // Act
            var message = command.Execute(parameters);

            studentFactoryMock.Verify(f => f.CreateStudent(parameters[0], parameters[1], (Grade)int.Parse(parameters[2])), Times.Once);

            // Senseless. Needs integration test.
            repositoryMock.Verify(r => r.Add(studentMock.Object), Times.Once);
        }
    }
}
