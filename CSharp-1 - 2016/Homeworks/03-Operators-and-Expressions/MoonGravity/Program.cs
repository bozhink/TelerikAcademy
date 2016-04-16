namespace MoonGravity
{
	using System;

	public class MainClass
	{
		private const double MoonToEarthGravityRatio = 0.17;
		private const string OutputFormat = "f3";

		public static void Main (string[] args)
		{
			double weightOnEarth = double.Parse (Console.ReadLine ());
			double weightOnMoon = MoonToEarthGravityRatio * weightOnEarth;

			Console.WriteLine (weightOnMoon.ToString(OutputFormat));
		}
	}
}
