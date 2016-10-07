namespace SchoolSystem.Tests
{
    using System;
    using NUnit.Framework;
    using SchoolSystem.Contracts;
    using SchoolSystem.Models;
    using SchoolSystem.Types;

    [TestFixture]
    public class MarkTests
    {
        [Test(Description = "Mark with valid parameters in constructor should return instance of IMark")]
        public void Mark_WithValidParametersInConstructor_ShouldReturnInstanceOfIMark()
        {
            // Arrange + Act
            var subject = Subject.Math;
            var value = 3.50f;

            var mark = new Mark(subject, value);

            // Assert
            Assert.IsInstanceOf<IMark>(mark);
        }

        [Test(Description = "Mark with valid parameters in constructor should set properly subject and value")]
        public void Mark_WithValidParametersInConstructor_ShouldSetProperlySubjectAndValue()
        {
            // Arrange + Act
            var subject = Subject.Math;
            var value = 3.50f;

            var mark = new Mark(subject, value);

            // Assert
            Assert.AreEqual(subject, mark.Subject);
            Assert.AreEqual(value, mark.Value);
        }

        [Test(Description = "Mark with invalid value parameter in constructor should throw ArgumentOutOfRangeException with Value as ParamName")]
        [TestCase(1.9f)]
        [TestCase(6.5f)]
        [TestCase(0.0f)]
        [TestCase(-0.001f)]
        [TestCase(-20.0f)]
        [TestCase(8.0f)]
        public void Mark_WithInvalidValueParameterInConstructor_ShouldThrowArgumentOutOfRangeException(float value)
        {
            // Arrange
            var subject = Subject.Math;

            // Act + Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new Mark(subject, value));
            Assert.AreEqual(nameof(Mark.Value), exception.ParamName);
        }
    }
}
