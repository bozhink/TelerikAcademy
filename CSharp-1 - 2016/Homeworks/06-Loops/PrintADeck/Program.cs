namespace PrintADeck
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            const string FacesString = "234567891JQKA";
            char[] faces = FacesString.ToArray();

            char input = Console.ReadLine().ToArray()[0];

            int position = FacesString.IndexOf(input);
            for (int i = 0; i <= position; ++i)
            {
                Console.WriteLine(
                    "{0} of {1}, {0} of {2}, {0} of {3}, {0} of {4}",
                    faces[i] == '1' ? "10" : faces[i].ToString(),
                    Suits.Spades.ToString().ToLower(),
                    Suits.Clubs.ToString().ToLower(),
                    Suits.Hearts.ToString().ToLower(),
                    Suits.Diamonds.ToString().ToLower());
            }
        }
    }

    public enum Suits
    {
        Spades,
        Clubs,
        Hearts,
        Diamonds
    }
}