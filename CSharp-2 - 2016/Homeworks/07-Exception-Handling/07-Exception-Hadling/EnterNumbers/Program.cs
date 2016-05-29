namespace EnterNumbers
{
	using System;
	using System.Collections.Generic;

	public class MainClass
	{
		private const int NumberOfExpectedNumbers = 10;
		private const int MinimalNumber = 1;
		private const int MaximalNumber = 100;

		private static readonly List<int> Numbers = new List<int> ();

		public static void Main (string[] args)
		{
			try {
				ReadNumber (MinimalNumber, MaximalNumber);

				Console.Write ("{0} < ", MinimalNumber);
				Console.Write (string.Join (" < ", Numbers));
				Console.Write (" < {0}", MaximalNumber);
				Console.WriteLine ();

			} catch {
				Console.WriteLine ("Exception");
			}
		}

		private static void ReadNumber (int start, int end)
		{
			int lastNumber = start;
			for (int i = 0; i < NumberOfExpectedNumbers; ++i) {
				string input = Console.ReadLine ();
				int number;
				if (int.TryParse (input, out number) && (number > lastNumber) && (number < end)) {
					Numbers.Add (number);
					lastNumber = number;
				} else {
					throw new ArgumentException ();
				}
			}
		}
	}
}
