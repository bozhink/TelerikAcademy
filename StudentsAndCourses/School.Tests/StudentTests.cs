namespace School.Tests
{
    using System;
    using System.Linq;

    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_ConstuctorWithValidIdAndName_ShouldReturnValidObject()
        {
            var student = new Student(20000, "Pesho");
            Assert.IsNotNull(student, "Student should be a valid object.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_ConstuctorWithTooSmallIdAndValidName_ShouldThowArgumentOutOfRangeException()
        {
            var student = new Student(Constants.MinimalStudentIdValue - 1, "Pesho");
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_ConstuctorWithTooLargeIdAndValidName_ShouldThowArgumentOutOfRangeException()
        {
            var student = new Student(Constants.MaximalStudentIdValue + 1, "Pesho");
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_ConstuctorNullNameAndValidId_ShouldThowArgumentNullException()
        {
            var student = new Student(20000, null);
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_ConstuctorEmptyNameAndValidId_ShouldThowArgumentNullException()
        {
            var student = new Student(20000, string.Empty);
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_ConstuctorWhiteSpaceNameAndValidId_ShouldThowArgumentNullException()
        {
            var student = new Student(20000, "  ");
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_JoinToNullCourse_ShouldThowArgumentNullException()
        {
            var student = new Student(20000, "Pesho");
            student.JoinToCourse(null);

            Assert.Fail("This should not work.");
        }

        [TestMethod]
        public void Student_JoinToValidCourse_ShouldIncrementNumberOfStudentsInCourseBy1()
        {
            var course = new Course();
            var initialNumberOfStudents = course.Students.Count;

            var student = new Student(20000, "Pesho");
            student.JoinToCourse(course);

            Assert.AreEqual(1, course.Students.Count - initialNumberOfStudents, "Number of student in the course should be incremented by 1.");
        }

        [TestMethod]
        public void Student_JoinToValidCourse_ShouldAddStudentCorrectly()
        {
            var course = new Course();

            var student = new Student(20000, "Pesho");
            student.JoinToCourse(course);

            var studentInCourse = course.Students.First(s => s.Id == student.Id && s.Name == student.Name);
            Assert.AreSame(student, studentInCourse, "Student should be joined to course correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_LeaveNullCourse_ShouldThowArgumentNullException()
        {
            var student = new Student(20000, "Pesho");
            student.LeaveCourse(null);

            Assert.Fail("This should not work.");
        }

        [TestMethod]
        public void Student_LeaveValidCourse_ShouldDecrementNumberOfStudentsInCourseBy1()
        {
            var course = new Course();
            var student = new Student(20000, "Pesho");
            course.AddStudent(student);
            var initialNumberOfStudents = course.Students.Count;

            student.LeaveCourse(course);

            Assert.AreEqual(1, initialNumberOfStudents - course.Students.Count, "Number of student in the course should be decremented by 1.");
        }

        [TestMethod]
        public void Student_LeaveValidCourse_ShouldRemoveStudentCorrectly()
        {
            var course = new Course();
            var student = new Student(20000, "Pesho");
            course.AddStudent(student);

            student.LeaveCourse(course);

            var studentInCourse = course.Students.FirstOrDefault(s => s.Id == student.Id && s.Name == student.Name);
            Assert.IsNull(studentInCourse, "Student should leave to course correctly.");
        }
    }
}
