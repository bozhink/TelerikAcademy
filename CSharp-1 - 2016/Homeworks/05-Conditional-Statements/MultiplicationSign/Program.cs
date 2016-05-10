namespace MultiplicationSign
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			double a = double.Parse (Console.ReadLine ());
			double b = double.Parse (Console.ReadLine ());
			double c = double.Parse (Console.ReadLine ());

			int signa = a > 0 ? 1 : a == 0 ? 0 : -1;
			int signb = b > 0 ? 1 : b == 0 ? 0 : -1;
			int signc = c > 0 ? 1 : c == 0 ? 0 : -1;

			int sign = signa * signb * signc;

			if (sign > 0) {
				Console.WriteLine ("+");
			} else if (sign == 0) {
				Console.WriteLine ("0");
			} else {
				Console.WriteLine ("-");
			}
						
		}
	}
}
