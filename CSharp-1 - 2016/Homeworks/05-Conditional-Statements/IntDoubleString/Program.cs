namespace IntDoubleString
{
	using System;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			string type = Console.ReadLine ();

			switch (type) {
			case "integer":
				int i = int.Parse (Console.ReadLine ());
				Console.WriteLine (i + 1);
				break;

			case "real":
				double a = double.Parse (Console.ReadLine ());
				Console.WriteLine ((a + 1.0).ToString ("f2"));
				break;

			case "text":
				string input = Console.ReadLine ();
				Console.WriteLine ("{0}*", input);
				break;
			}
		}
	}
}
