namespace PlayCard
{
	using System;
	using System.Collections.Generic;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			const string ValidCardFaces = "2 3 4 5 6 7 8 9 10 J Q K A";
			var faces = new HashSet<string>(ValidCardFaces.Split (' '));

			string input = Console.ReadLine ();

			if (faces.Contains (input)) {
				Console.WriteLine ("yes {0}", input);
			} else {
				Console.WriteLine ("no {0}", input);
			}
		}
	}
}
