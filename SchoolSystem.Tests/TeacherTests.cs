namespace SchoolSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;

    using SchoolSystem.Contracts;
    using SchoolSystem.Models;
    using SchoolSystem.Types;

    [TestFixture]
    public class TeacherTests
    {
        [Test(Description = "Teacher with valid parameters in constructor should return instance of ITeacher")]
        public void Teacher_WithValidParametersInConstructor_ShouldReturnInstanceOfITeacher()
        {
            // Arrange
            var firstName = "Gosho";
            var lastName = "Vesheff";
            var subject = Subject.Math;

            // Act
            var teacher = new Teacher(firstName, lastName, subject);

            // Assert
            Assert.IsInstanceOf<ITeacher>(teacher);
        }

        [Test(Description = "Teacher with valid parameters in constructor should properly set FirstName, LastName and subject")]
        public void Teacher_WithValidParametersInConstructor_ShouldProperlySetFirstNameLastNameSubject()
        {
            // Arrange
            var firstName = "Gosho";
            var lastName = "Vesheff";
            var subject = Subject.Math;

            // Act
            var teacher = new Teacher(firstName, lastName, subject);

            // Assert
            Assert.AreEqual(firstName, teacher.FirstName);
            Assert.AreEqual(lastName, teacher.LastName);
            Assert.AreEqual(subject, teacher.Subject);
        }

        [Test(Description = "Teacher with invalid length of FirstName and valid other parameters in constructor should throw ArgumentOutOfRangeException with FirstName as ParamName")]
        [TestCase("A")]
        [TestCase("Some remarkably long first name of an Indian is supposed to be this string")]
        public void Teacher_WithInvalidLengthOfFirstNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string firstName)
        {
            // Arrange
            var lastName = "Vesheff";
            var subject = Subject.Math;

            // Act + Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Teacher(firstName, lastName, subject));

            Assert.AreEqual(nameof(Teacher.FirstName), exception.ParamName);
        }

        [Test(Description = "Teacher with null or whitespace FirstName and valid other parameters in constructor should throw ArgumentNullException with FirstName as ParamName")]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void Teacher_WithNullOrWhitespaceFirstNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string firstName)
        {
            // Arrange
            var lastName = "Vesheff";
            var subject = Subject.Math;

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Teacher(firstName, lastName, subject));

            Assert.AreEqual(nameof(Teacher.FirstName), exception.ParamName);
        }

        [Test(Description = "Teacher with invalid length of LastName and valid other parameters in constructor should throw ArgumentOutOfRangeException with FirstName as ParamName")]
        [TestCase("A")]
        [TestCase("Some remarkably long last name of an Indian is supposed to be this string")]
        public void Teacher_WithInvalidLengthOfLastNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string lastName)
        {
            // Arrange
            var firstName = "Pesho";
            var subject = Subject.Math;

            // Act + Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Teacher(firstName, lastName, subject));

            Assert.AreEqual(nameof(Teacher.LastName), exception.ParamName);
        }

        [Test(Description = "Teacher with null or whitespace LastName and valid other parameters in constructor should throw ArgumentNullException with FirstName as ParamName")]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void Teacher_WithNullOrWhitespaceLastNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string lastName)
        {
            // Arrange
            var firstName = "Pesho";
            var subject = Subject.Math;

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Teacher(firstName, lastName, subject));

            Assert.AreEqual(nameof(Teacher.LastName), exception.ParamName);
        }

        [Test(Description = "Teacher AddMark with valid parameters should call IStudent.Marks exactly once")]
        public void Teacher_AddMark_WithValidParameters_ShouldCallIStudentMarksExactlyOnce()
        {
            // Arrange
            const string StudentFirstName = "Pesho";
            const string StudentLastName = "Petrov";
            const Grade StudentGrade = Grade.Eighth;

            var studentMarks = new List<IMark>();

            var studentMock = new Mock<IStudent>();
            studentMock
                .Setup(s => s.FirstName)
                .Returns(StudentFirstName);
            studentMock
                .Setup(s => s.LastName)
                .Returns(StudentLastName);
            studentMock
                .Setup(s => s.Grade)
                .Returns(StudentGrade);
            studentMock
                .Setup(s => s.Marks)
                .Returns(studentMarks);

            const string TeacherFirstName = "Gosho";
            const string TeacherLastName = "Vesheff";
            const Subject Subject = Subject.Math;

            var teacher = new Teacher(TeacherFirstName, TeacherLastName, Subject);

            var markValue = 3.50f;

            // Act
            teacher.AddMark(studentMock.Object, markValue);

            // Assert
            studentMock.Verify(s => s.Marks, Times.Once);
        }

        [Test(Description = "Teacher AddMark with valid parameters should add corresponding mark correctly")]
        public void Teacher_AddMark_WithValidParameters_ShouldAddCorrespondingMarkCorrectly()
        {
            // Arrange
            const string StudentFirstName = "Pesho";
            const string StudentLastName = "Petrov";
            const Grade StudentGrade = Grade.Eighth;

            var studentMarks = new List<IMark>();

            var studentMock = new Mock<IStudent>();
            studentMock
                .Setup(s => s.FirstName)
                .Returns(StudentFirstName);
            studentMock
                .Setup(s => s.LastName)
                .Returns(StudentLastName);
            studentMock
                .Setup(s => s.Grade)
                .Returns(StudentGrade);
            studentMock
                .Setup(s => s.Marks)
                .Returns(studentMarks);

            const string TeacherFirstName = "Gosho";
            const string TeacherLastName = "Vesheff";
            const Subject Subject = Subject.Math;

            var teacher = new Teacher(TeacherFirstName, TeacherLastName, Subject);

            var markValue = 3.50f;

            // Act
            teacher.AddMark(studentMock.Object, markValue);

            // Assert
            Assert.AreEqual(1, studentMarks.Count);

            var mark = studentMarks.Single();
            Assert.AreEqual(markValue, mark.Value);
            Assert.AreEqual(Subject, mark.Subject);
        }

        [Test(Description = "Teacher AddMark with null student should throw ArgumentNullException with student as ParamName")]
        public void Teacher_AddMark_WithNullStudent_ShouldThrowArgumentNullExceptionWithStudentAsParamName()
        {
            // Arrange
            const string TeacherFirstName = "Gosho";
            const string TeacherLastName = "Vesheff";
            const Subject Subject = Subject.Math;

            var teacher = new Teacher(TeacherFirstName, TeacherLastName, Subject);

            var markValue = 3.50f;

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => teacher.AddMark(null, markValue));
            Assert.AreEqual("student", exception.ParamName);
        }

        [Test(Description = "Teacher AddMark with invalid mark value should throw ArgumentOutOfRangeException")]
        [TestCase(1.9f)]
        [TestCase(6.5f)]
        [TestCase(0.0f)]
        [TestCase(-0.001f)]
        [TestCase(-20.0f)]
        [TestCase(8.0f)]
        public void Teacher_AddMark_WithInvalidMarkValue_ShouldThrowArgumentOutOfRangeException(float markValue)
        {
            // Arrange
            const string StudentFirstName = "Pesho";
            const string StudentLastName = "Petrov";
            const Grade StudentGrade = Grade.Eighth;

            var studentMarks = new List<IMark>();

            var studentMock = new Mock<IStudent>();
            studentMock
                .Setup(s => s.FirstName)
                .Returns(StudentFirstName);
            studentMock
                .Setup(s => s.LastName)
                .Returns(StudentLastName);
            studentMock
                .Setup(s => s.Grade)
                .Returns(StudentGrade);
            studentMock
                .Setup(s => s.Marks)
                .Returns(studentMarks);

            const string TeacherFirstName = "Gosho";
            const string TeacherLastName = "Vesheff";
            const Subject Subject = Subject.Math;

            var teacher = new Teacher(TeacherFirstName, TeacherLastName, Subject);

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => teacher.AddMark(studentMock.Object, markValue));
        }

        [Test(Description = "Teacher AddMark with invalid mark value should not call IStudent.Mark")]
        [TestCase(1.9f)]
        [TestCase(6.5f)]
        [TestCase(0.0f)]
        [TestCase(-0.001f)]
        [TestCase(-20.0f)]
        [TestCase(8.0f)]
        public void Teacher_AddMark_WithInvalidMarkValue_ShouldNotCallIStudentMark(float markValue)
        {
            // Arrange
            const string StudentFirstName = "Pesho";
            const string StudentLastName = "Petrov";
            const Grade StudentGrade = Grade.Eighth;

            var studentMarks = new List<IMark>();

            var studentMock = new Mock<IStudent>();
            studentMock
                .Setup(s => s.FirstName)
                .Returns(StudentFirstName);
            studentMock
                .Setup(s => s.LastName)
                .Returns(StudentLastName);
            studentMock
                .Setup(s => s.Grade)
                .Returns(StudentGrade);
            studentMock
                .Setup(s => s.Marks)
                .Returns(studentMarks);

            const string TeacherFirstName = "Gosho";
            const string TeacherLastName = "Vesheff";
            const Subject Subject = Subject.Math;

            var teacher = new Teacher(TeacherFirstName, TeacherLastName, Subject);

            // Act
            try
            {
                teacher.AddMark(studentMock.Object, markValue);
            }
            catch
            {
            }

            // Assert
            studentMock.Verify(s => s.Marks, Times.Never);
        }
    }
}
