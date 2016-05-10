namespace Sort3Numbers
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			int a = int.Parse (Console.ReadLine ());
			int b = int.Parse (Console.ReadLine ());
			int c = int.Parse (Console.ReadLine ());

			if (a < b) {
				Swap (ref a, ref b);
			}

			if (a < c) {
				Swap (ref a, ref c);
			}

			if (b < c) {
				Swap (ref b, ref c);
			}

			Console.WriteLine ("{0} {1} {2}", a, b, c);
		}

		private static void Swap(ref int a, ref int b) {
			int swap = a;
			a = b;
			b = swap;
		}
	}
}
