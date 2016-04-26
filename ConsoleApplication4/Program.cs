namespace ConsoleApplication4
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int sizeOfCat = int.Parse(Console.ReadLine());
            char symbolToDraw = Console.ReadLine().ToCharArray()[0];

            int headHeight = (sizeOfCat - 10) / 4 + 1;

            // First row
            {
                Console.Write(" ");
                Console.Write(symbolToDraw);
                for (int i = 0; i < headHeight; ++i)
                {
                    Console.Write(" ");
                }

                Console.Write(symbolToDraw);
            }

            Console.WriteLine();

            // Second row
            {
                for (int row = 1; row <= headHeight; ++row)
                {
                    Console.Write(" ");

                    for (int col = 1; col <= headHeight + 2; ++col)
                    {
                        Console.Write(symbolToDraw);
                    }

                    Console.WriteLine();
                }
            }

            // Neck
            {
                for (int i = 0; i < headHeight; ++i)
                {
                    Console.Write(" ");
                    Console.Write(" ");
                    for (int col = 2; col < 2 + headHeight; ++col)
                    {
                        Console.Write(symbolToDraw);
                    }

                    Console.WriteLine();
                }
            }

            // Body
            for (int i = 0; i < headHeight; ++i)
            {
                Console.Write(" ");

                for (int col = 1; col < 3 + headHeight; ++col)
                {
                    Console.Write(symbolToDraw);
                }

                Console.WriteLine();
            }

            {
                // Top of tail
                Console.Write(" ");

                for (int col = 1; col < 3 + headHeight; ++col)
                {
                    Console.Write(symbolToDraw);
                }

                for (int i = 3 + headHeight; i < 6 + headHeight; ++i)
                {
                    Console.Write(" ");
                }

                for (int i = 6 + headHeight; i < 7 + headHeight + headHeight; ++i)
                {
                    Console.Write(symbolToDraw);
                }

                Console.WriteLine();
            }

            // Legs
            for (int i = 0; i < headHeight + 2; ++i)
            {
                for (int col = 0; col < 4 + headHeight; ++col)
                {
                    Console.Write(symbolToDraw);
                }

                for (int j = headHeight + 2; j < 4 + headHeight; ++j)
                {
                    Console.Write(" ");
                }


                Console.Write(symbolToDraw);
                Console.WriteLine();
            }

            // Bottom
            {
                for (int col = 0; col < 4 + headHeight; ++col)
                {
                    Console.Write(symbolToDraw);
                }

                Console.Write(" ");
                Console.Write(symbolToDraw);
                Console.Write(symbolToDraw);

                Console.WriteLine();
            }

            // End
            {
                Console.Write(" ");
                for (int col = 1; col < 6 + headHeight; ++col)
                {
                    Console.Write(symbolToDraw);
                }

                Console.WriteLine();
            }
        }
    }
}
