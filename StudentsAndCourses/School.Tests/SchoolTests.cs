namespace School.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_WithDefaultConstructor_ShouldReturnValidObject()
        {
            var school = new School();

            Assert.IsNotNull(school, "School should not be null.");
        }

        [TestMethod]
        public void School_WithDefaultConstructor_ShouldInitializeStudentsCollection()
        {
            var school = new School();

            Assert.IsNotNull(school.Students, "Students collection should not be null.");
        }

        [TestMethod]
        public void School_WithDefaultConstructor_ShouldInitializeEmptyStudentsCollection()
        {
            var school = new School();

            Assert.AreEqual(0, school.Students.Count, "Students collection should not be empty.");
        }

        [TestMethod]
        public void School_WithDefaultConstructor_ShouldInitializeCoursesCollection()
        {
            var school = new School();

            Assert.IsNotNull(school.Courses, "Courses collection should not be null.");
        }

        [TestMethod]
        public void School_WithDefaultConstructor_ShouldInitializeEmptyCoursesCollection()
        {
            var school = new School();

            Assert.AreEqual(0, school.Courses.Count, "Courses collection should not be empty.");
        }
    }
}
