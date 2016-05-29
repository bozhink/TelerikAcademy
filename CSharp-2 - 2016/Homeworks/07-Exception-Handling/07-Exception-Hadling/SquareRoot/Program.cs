namespace SquareRoot
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			try {
				string input = Console.ReadLine ();
				double number = double.Parse (input);

				if (number < 0) {

					throw new ArgumentException();

				}

				Console.WriteLine ("{0:f3}", Math.Sqrt (number));
			
			} catch {
			
				Console.WriteLine ("Invalid number");
			
			} finally {
			
				Console.WriteLine ("Good bye");
			
			}
		}
	}
}
