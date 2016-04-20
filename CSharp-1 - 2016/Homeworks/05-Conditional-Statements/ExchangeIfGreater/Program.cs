namespace ExchangeIfGreater
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			double a = double.Parse (Console.ReadLine ());
			double b = double.Parse (Console.ReadLine ());

			double swap;

			if (a > b) {
				swap = b;
				b = a;
				a = swap;
			}

			Console.WriteLine ("{0} {1}", a, b);
		}
	}
}
