namespace ExchangeVaraibleValues
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			int a = 5;
			int b = 10;
			Console.WriteLine ("{0} {1}", a, b);

			int swap = a;
			a = b;
			b = swap;
			Console.WriteLine ("{0} {1}", a, b);
		}
	}
}
