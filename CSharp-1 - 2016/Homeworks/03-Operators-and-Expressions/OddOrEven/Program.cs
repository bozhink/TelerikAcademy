namespace OddOrEven
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			int input = int.Parse (Console.ReadLine ());

			if (2 * (input / 2) == input) {
				Console.WriteLine ("even {0}", input);
			} else {
				Console.WriteLine ("odd {0}", input);
			}
		}
	}
}
