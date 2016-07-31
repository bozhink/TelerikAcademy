namespace School.Tests
{
    using System;
    using System.Reflection;
    using Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_WithDefaultConstuctor_ShouldReturnValidObject()
        {
            var course = new Course();

            Assert.IsNotNull(course, "Course object should not be null.");
        }

        [TestMethod]
        public void Course_WithDefaultConstuctor_ShouldInitializeStudentsField()
        {
            var course = new Course();

            string fieldName = "students";
            var field = course.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);
            var fieldValue = field?.GetValue(course);

            Assert.IsNotNull(fieldValue, "Students field should not be null.");
        }

        [TestMethod]
        public void Course_WithDefaultConstuctor_StudentsPropertyShouldReturnValidCollection()
        {
            var course = new Course();

            Assert.IsNotNull(course.Students, "Students property should not be null.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_AddNullStudent_ShouldThrowArgumentNullException()
        {
            var course = new Course();
            course.AddStudent(null);
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        public void Course_AddOneValidStudent_ShouldSetOneStudentToCollection()
        {
            var student = new Student(20000, "Pesho");

            var course = new Course();
            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count, "Number of students should be 1.");
        }

        [TestMethod]
        public void Course_AddValidNumberOfValidStudents_ShouldSetCorrectNumberOfStudentToCollection()
        {
            const int NumberOfStudentsToAdd = Constants.MaximalNumberOfStudentsPerCourse - 1;
            var course = new Course();

            for (int i = 0; i < NumberOfStudentsToAdd; i++)
            {
                var student = new Student(20000 + i, "Pesho" + i);
                course.AddStudent(student);
            }

            Assert.AreEqual(NumberOfStudentsToAdd, course.Students.Count, $"Number of students should be {NumberOfStudentsToAdd}.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_AddTooMuchValidStudents_ShouldThrow()
        {
            const int NumberOfStudentsToAdd = Constants.MaximalNumberOfStudentsPerCourse;
            var course = new Course();

            for (int i = 0; i < NumberOfStudentsToAdd; i++)
            {
                var student = new Student(20000 + i, "Pesho" + i);
                course.AddStudent(student);
            }

            Assert.Fail("This should not work.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_RemoveNullStudent_ShouldThrowArgumentNullException()
        {
            var course = new Course();
            course.RemoveStudent(null);
            Assert.Fail("This should not work.");
        }

        [TestMethod]
        public void Course_RemoveValidStudent_ShouldDecrementNumberOfStudentsBy1()
        {
            var course = new Course();
            var student = new Student(20000, "Pesho");
            course.AddStudent(student);

            int initialNumberOfStudents = course.Students.Count;
            course.RemoveStudent(student);

            Assert.AreEqual(1, initialNumberOfStudents - course.Students.Count, "Number of students after removing a valid student should be decreased by 1.");
        }

        [TestMethod]
        public void Course_RemoveValidStudent_ShouldReturnTrue()
        {
            var course = new Course();
            var student = new Student(20000, "Pesho");
            course.AddStudent(student);

            var result = course.RemoveStudent(student);
            Assert.IsTrue(result, "Remove a valid student should return true.");
        }

        [TestMethod]
        public void Course_RemoveValidButNotPresentStudent_ShouldReturnFalse()
        {
            var course = new Course();
            var student = new Student(20000, "Pesho");
            course.AddStudent(student);

            student = new Student(20001, "Pesho 1");

            var result = course.RemoveStudent(student);
            Assert.IsFalse(result, "Remove a valid but not present student should return true.");
        }
    }
}
