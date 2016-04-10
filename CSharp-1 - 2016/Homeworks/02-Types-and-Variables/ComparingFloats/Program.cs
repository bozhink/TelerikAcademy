namespace ComparingFloats
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			double a = double.Parse (Console.ReadLine ());
			double b = double.Parse (Console.ReadLine ());

			double eps = 0.000001;
			Console.WriteLine ((Math.Abs (a - b) < eps).ToString().ToLower());
		}
	}
}
