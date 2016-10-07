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
    public class StudentTests
    {
        [Test(Description = "Student with valid parameters in constructor should return instance of IStudent")]
        public void Student_WithValidParametersInConstructor_ShouldReturnInstanceOfIStudent()
        {
            // Arrange
            var firstName = "Gosho";
            var lastName = "Vesheff";
            var grade = Grade.Eighth;

            // Act
            var student = new Student(firstName, lastName, grade);

            // Assert
            Assert.IsInstanceOf<IStudent>(student);
        }

        [Test(Description = "Student with valid parameters in constructor should properly set FirstName, LastName and grade")]
        public void Student_WithValidParametersInConstructor_ShouldProperlySetFirstNameLastNameGrade()
        {
            // Arrange
            var firstName = "Gosho";
            var lastName = "Vesheff";
            var grade = Grade.Eighth;

            // Act
            var student = new Student(firstName, lastName, grade);

            // Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(grade, student.Grade);
        }

        [Test(Description = "Student with invalid length of FirstName and valid other parameters in constructor should throw ArgumentOutOfRangeException with FirstName as ParamName")]
        [TestCase("A")]
        [TestCase("Some remarkably long first name of an Indian is supposed to be this string")]
        public void Student_WithInvalidLengthOfFirstNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string firstName)
        {
            // Arrange
            var lastName = "Vesheff";
            var grade = Grade.Eighth;

            // Act + Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Student(firstName, lastName, grade));

            Assert.AreEqual(nameof(Student.FirstName), exception.ParamName);
        }

        [Test(Description = "Student with null or whitespace FirstName and valid other parameters in constructor should throw ArgumentNullException with FirstName as ParamName")]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void Student_WithNullOrWhitespaceFirstNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string firstName)
        {
            // Arrange
            var lastName = "Vesheff";
            var grade = Grade.Eighth;

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Student(firstName, lastName, grade));

            Assert.AreEqual(nameof(Student.FirstName), exception.ParamName);
        }

        [Test(Description = "Student with invalid length of LastName and valid other parameters in constructor should throw ArgumentOutOfRangeException with FirstName as ParamName")]
        [TestCase("A")]
        [TestCase("Some remarkably long last name of an Indian is supposed to be this string")]
        public void Student_WithInvalidLengthOfLastNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string lastName)
        {
            // Arrange
            var firstName = "Pesho";
            var grade = Grade.Eighth;

            // Act + Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Student(firstName, lastName, grade));

            Assert.AreEqual(nameof(Student.LastName), exception.ParamName);
        }

        [Test(Description = "Student with null or whitespace LastName and valid other parameters in constructor should throw ArgumentNullException with FirstName as ParamName")]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(null)]
        public void Student_WithNullOrWhitespaceLastNameAndValidOtherParametersInConstructor_ShouldThrowArgumentOutOfRangeExceptionWithFirstNameAsParamName(string lastName)
        {
            // Arrange
            var firstName = "Pesho";
            var grade = Grade.Eighth;

            // Act + Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Student(firstName, lastName, grade));

            Assert.AreEqual(nameof(Student.LastName), exception.ParamName);
        }

        [Test(Description = "Student Marks add single valid mark should add it properly")]
        public void Student_Marks_AddSingleValidMarkShouldAddItProperly()
        {
            // Arrange
            var firstName = "Gosho";
            var lastName = "Vesheff";
            var grade = Grade.Eighth;
            var student = new Student(firstName, lastName, grade);

            var markSubject = Subject.English;
            var markValue = 3.5f;

            var markMock = new Mock<IMark>();
            markMock
                .Setup(m => m.Subject)
                .Returns(markSubject);
            markMock
                .Setup(m => m.Value)
                .Returns(markValue);

            // Act
            student.Marks.Add(markMock.Object);

            // Assert
            Assert.AreEqual(1, student.Marks.Count);

            var mark = student.Marks.Single();
            Assert.AreEqual(markSubject, mark.Subject);
            Assert.AreEqual(markValue, mark.Value);
        }
    }
}
