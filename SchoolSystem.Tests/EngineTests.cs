namespace SchoolSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using Moq;
    using NUnit.Framework;

    using SchoolSystem.Constants;
    using SchoolSystem.Contracts;
    using SchoolSystem.Core;
    using SchoolSystem.Models;
    using SchoolSystem.Types;

    [TestFixture]
    public class EngineTests
    {
        [Test(Description = "Engine with valid parameters in constructor should set correctly reader and writer")]
        public void Engine_WithValidParametersInConstructor_ShouldSetCorrectlyReaderAndWriter()
        {
            // Arrange
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();

            // Act
            var engine = new Engine(readerMock.Object, writerMock.Object);

            // Assert
            var reader = this.GetInstanceField(typeof(Engine), engine, "reader");
            var writer = this.GetInstanceField(typeof(Engine), engine, "writer");

            Assert.AreSame(reader, readerMock.Object);
            Assert.AreSame(writer, writerMock.Object);
        }

        [Test(Description = "Engine with null reader in constructor should throw ArgumentNullException with reader as ParamName")]
        public void Engine_WithNullReaderInConstructor_ShouldThrowArgumentNullExceptionWithReaderAsParamName()
        {
            // Arrange
            var writerMock = new Mock<IWriter>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>new Engine(null, writerMock.Object));

            Assert.AreEqual("reader", exception.ParamName);
        }

        [Test(Description = "Engine with null writer in constructor should throw ArgumentNullException with writer as ParamName")]
        public void Engine_WithNullWriterInConstructor_ShouldThrowArgumentNullExceptionWithWriterAsParamName()
        {
            // Arrange
            var readerMock = new Mock<IReader>();

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Engine(readerMock.Object, null));

            Assert.AreEqual("writer", exception.ParamName);
        }

        [Test(Description = "Engine Run first zero test")]
        [Timeout(5000)]
        public void Engine_Run_FirstZeroTest()
        {
            // Arrange
            var inputLines = new Queue<string>(new string[]
            {
                "CreateStudent Pesho Peshev 11",
                "CreateStudent Gosho Peshev 9",
                "StudentListMarks 1",
                "End"
            });

            var readerMock = new Mock<IReader>();
            readerMock
                .Setup(r => r.ReadLine())
                .Returns(inputLines.Dequeue);

            var outputLines = new List<string>();

            var writerMock = new Mock<IWriter>();
            writerMock
                .Setup(w => w.WriteLine(It.IsAny<string>()))
                .Callback((string message) => outputLines.Add(message));

            var engine = new Engine(readerMock.Object, writerMock.Object);

            // Act
            engine.Run();

            // Assert
            Assert.AreEqual(3, outputLines.Count);
            Assert.AreEqual(
                "A new student with name Pesho Peshev, grade Eleventh and ID 0 was created.",
                outputLines[0]);
            Assert.AreEqual(
                "A new student with name Gosho Peshev, grade Ninth and ID 1 was created.",
                outputLines[1]);
            Assert.AreEqual(
                "This student has no marks.",
                outputLines[2]);
        }

        [Test(Description = "Engine Run second zero test")]
        [Timeout(5000)]
        public void Engine_Run_SecondZeroTest()
        {
            // Arrange
            var inputLines = new Queue<string>(new string[]
            {
                "CreateStudent Pesho Petrov 10",
                "CreateTeacher Gosho Vesheff 2",
                "TeacherAddMark 0 0 3",
                "End"
            });

            var readerMock = new Mock<IReader>();
            readerMock
                .Setup(r => r.ReadLine())
                .Returns(inputLines.Dequeue);

            var outputLines = new List<string>();

            var writerMock = new Mock<IWriter>();
            writerMock
                .Setup(w => w.WriteLine(It.IsAny<string>()))
                .Callback((string message) => outputLines.Add(message));

            var engine = new Engine(readerMock.Object, writerMock.Object);

            // Act
            engine.Run();

            // Assert
            Assert.AreEqual(3, outputLines.Count);
            Assert.AreEqual(
                "A new student with name Pesho Petrov, grade Tenth and ID 0 was created.",
                outputLines[0]);
            Assert.AreEqual(
                "A new teacher with name Gosho Vesheff, subject Math and ID 0 was created.",
                outputLines[1]);
            Assert.AreEqual(
                "Teacher Gosho Vesheff added mark 3 to student Pesho Petrov in Math.",
                outputLines[2]);
        }

        [Test(Description = "Engine Run third zero test")]
        [Timeout(5000)]
        public void Engine_Run_ThirdZeroTest()
        {
            // Arrange
            var inputLines = new Queue<string>(new string[]
            {
                "CreateStudent Pesho Petrov 6",
                "CreateStudent Gosho Petrov 6",
                "CreateTeacher Gosho Vesheff 2",
                "TeacherAddMark 0 1 3",
                "End"
            });

            var readerMock = new Mock<IReader>();
            readerMock
                .Setup(r => r.ReadLine())
                .Returns(inputLines.Dequeue);

            var outputLines = new List<string>();

            var writerMock = new Mock<IWriter>();
            writerMock
                .Setup(w => w.WriteLine(It.IsAny<string>()))
                .Callback((string message) => outputLines.Add(message));

            var engine = new Engine(readerMock.Object, writerMock.Object);

            // Act
            engine.Run();

            // Assert
            Assert.AreEqual(4, outputLines.Count);
            Assert.AreEqual(
                "A new student with name Pesho Petrov, grade Sixth and ID 0 was created.",
                outputLines[0]);
            Assert.AreEqual(
                "A new student with name Gosho Petrov, grade Sixth and ID 1 was created.",
                outputLines[1]);
            Assert.AreEqual(
                "A new teacher with name Gosho Vesheff, subject Math and ID 0 was created.",
                outputLines[2]);
            Assert.AreEqual(
                "Teacher Gosho Vesheff added mark 3 to student Gosho Petrov in Math.",
                outputLines[3]);
        }

        private object GetInstanceField(Type type, object instance, string fieldName)
        {
            var bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Static;
            var fieldInfo = type.GetField(fieldName, bindFlags);
            return fieldInfo.GetValue(instance);
        }
    }
}
