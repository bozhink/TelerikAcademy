namespace Version.Tests
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var testObject = new ClassWithVersionAttribute();

            Console.WriteLine(testObject.GetVersion());
        }
    }
}
