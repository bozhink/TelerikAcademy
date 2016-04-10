namespace PrintTheAsciiTable
{
	using System;
	using System.Text;

	public class MainClass
	{
		public static void Main (string[] args)
		{
			var stringBuilder = new StringBuilder ();

			for (int i = 33; i <= 126; ++i) {
				stringBuilder.Append ((char)i);
			}

			var result = stringBuilder.ToString ();
			if (result.Length != 94) {
				throw new ApplicationException ();
			} else {
				Console.WriteLine (result);
			}
		}
	}
}
