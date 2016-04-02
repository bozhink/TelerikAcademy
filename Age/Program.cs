namespace Age
{
    using System;
    using System.Globalization;

    public class Program
    {
        public static void Main(string[] args)
        {
            CultureInfo us = new CultureInfo("en-US");

            string birthdayString = Console.ReadLine();

            DateTime birthday;
            if (!DateTime.TryParse(birthdayString, us, DateTimeStyles.None, out birthday))
            {
                return;
            }

            var now = DateTime.Now;
            var currentAge = now - birthday;

            var zero = new TimeSpan(0);
            if (currentAge < zero)
            {
                currentAge = zero;
            }

            int age = currentAge.Days / 365;

            Console.WriteLine(age);
            Console.WriteLine(age + 10);
        }
    }
}