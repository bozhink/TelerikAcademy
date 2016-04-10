namespace StringsAndObjects
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			string hello = "Hello";
			string world = "World";
			object helloWorld = hello + " " + world;
			string message = (string)helloWorld;
			Console.WriteLine (message);
		}
	}
}
