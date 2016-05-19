namespace LeapYear
{
using System;

public class IsLeapYear
{
   public static void Main()
   {
	   int year = int.Parse(Console.ReadLine());
	   
	   if (DateTime.IsLeapYear(year))
	   {
		   Console.WriteLine("Leap");
	   }
	   else
	   {
		   Console.WriteLine("Common");
	   }
   }
}
}