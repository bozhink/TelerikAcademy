namespace ConsoleApplication4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            int sizeOfCat = int.Parse(Console.ReadLine());
            char symbolToDraw = Console.ReadLine().ToCharArray()[0];

            char[][] canvas = new char[sizeOfCat][];
            for (int i = 0; i < sizeOfCat; ++i)
            {
                canvas[i] = new char[sizeOfCat];
            }


        }
    }
}
