namespace BiggestOf3
{
	using System;

	public class MainClass
	{
		private const int NumberOfItemsToRead = 3;

		public static void Main (string[] args)
		{
			double[] inputs = new double[NumberOfItemsToRead];

			for (int i = 0; i < NumberOfItemsToRead; ++i) {
				inputs [i] = double.Parse (Console.ReadLine ());
			}

			double biggest = inputs [0];
			for (int i = 1; i < NumberOfItemsToRead; ++i) {
				if (biggest < inputs [i]) {
					biggest = inputs [i];
				}
			}

			Console.WriteLine (biggest);
		}
	}
}
