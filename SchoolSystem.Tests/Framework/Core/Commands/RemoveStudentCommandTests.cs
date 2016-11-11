namespace SchoolSystem.Tests.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;
    using Moq;
    using NUnit.Framework;
    using SchoolSystem.Framework.Core.Commands;
    using SchoolSystem.Framework.Data.Contracts.Repositories;
    using SchoolSystem.Framework.Models.Contracts;

    [TestFixture(TestOf = typeof(RemoveStudentCommand))]
    public class RemoveStudentCommandTests
    {
        private const string RepositoryFieldName = "repository";
        private const string ParametersParameterName = "parameters";

        [Test]
        public void RemoveStudentCommand_WithValidParametersInDefaultConstructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var repositoryMock = new Mock<IStudentRepository>();

            // Act
            var command = new RemoveStudentCommand(repositoryMock.Object);

            // Assert
            Assert.IsNotNull(command);

            var repository = PrivateField.GetInstanceField<RemoveStudentCommand>(command, RepositoryFieldName);
            Assert.AreSame(repositoryMock.Object, repository);
        }

        [Test]
        public void RemoveStudentCommand_WithNullRepositoryInDefaultConstructor_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                var command = new RemoveStudentCommand(null);
            });

            Assert.AreEqual(exception.ParamName, RepositoryFieldName);
        }

        [Test]
        public void RemoveStudentCommand_ExecuteWithNullParameters_ShouldThorwArgumentNullExceptionWithCorrectParamName()
        {
            // Arrange
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new RemoveStudentCommand(repositoryMock.Object);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                command.Execute(null);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);

            repositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            repositoryMock.Verify(r => r.Remove(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RemoveStudentCommand_ExecuteWithNotEnoughParameters_ShouldThorwArgumentExceptionWithCorrectParamName()
        {
            // Arrange
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new RemoveStudentCommand(repositoryMock.Object);

            var parameters = new List<string>();

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                command.Execute(parameters);
            });

            Assert.AreEqual(ParametersParameterName, exception.ParamName);

            repositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            repositoryMock.Verify(r => r.Remove(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RemoveStudentCommand_ExecuteWithInvalidGradeInParameters_ShouldThorwFormatException()
        {
            // Arrange
            var repositoryMock = new Mock<IStudentRepository>();
            var command = new RemoveStudentCommand(repositoryMock.Object);

            var parameters = "Pesho again".Split(' ').ToList();

            // Act
            var exception = Assert.Throws<FormatException>(() =>
            {
                command.Execute(parameters);
            });

            repositoryMock.Verify(r => r.GetById(It.IsAny<int>()), Times.Never);
            repositoryMock.Verify(r => r.Remove(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void RemoveStudentCommand_ExecuteWithValidPresentInDbId_ShouldWork()
        {
            // Arrange
            int id = 10;
            var parameters = id.ToString().Split(' ').ToList();

            var repositoryMock = new Mock<IStudentRepository>();
            repositoryMock.Setup(r => r.GetById(id))
                .Returns(new Mock<IStudent>().Object);

            var command = new RemoveStudentCommand(repositoryMock.Object);

            // Act
            var message = command.Execute(parameters);

            repositoryMock.Verify(r => r.GetById(id), Times.Once);
            repositoryMock.Verify(r => r.Remove(id), Times.Once);
        }

        [Test]
        public void RemoveStudentCommand_ExecuteWithValidNonPresentInDbId_ShouldThrowArgumentException()
        {
            // Arrange
            int id = 10;
            var parameters = id.ToString().Split(' ').ToList();

            var repositoryMock = new Mock<IStudentRepository>();

            var command = new RemoveStudentCommand(repositoryMock.Object);

            // Act
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var message = command.Execute(parameters);
            });

            StringAssert.Contains("key was not present", exception.Message);

            repositoryMock.Verify(r => r.GetById(id), Times.Once);
            repositoryMock.Verify(r => r.Remove(It.IsAny<int>()), Times.Never);
        }
    }
}
