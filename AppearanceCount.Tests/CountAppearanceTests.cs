namespace AppearanceCount.Tests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountAppearanceTests
    {
        [TestMethod]
        public void CountAppearance_WithZeroTestData_ShouldWork()
        {
            int n = int.Parse("8");
            int[] array = "28 6 21 6 -7856 73 73 -56".Split(' ').Select(s => int.Parse(s)).ToArray();
            int x = int.Parse("73");

            Assert.AreEqual(2, AppearanceCount.Program.CountAppearance(x, array), "Appearance count should be 2.");
        }
    }
}