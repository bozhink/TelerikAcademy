namespace FillTheMatrix
{
    using System;
    using System.Linq;

    public class Program
    {
        private static readonly int NumberOfDirections = Enum.GetNames(typeof(Direction)).Length;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char mode = Console.ReadLine().ToCharArray().FirstOrDefault();

            int[,] matrix = new int[n, n];

            switch (mode)
            {
                case 'a':
                    FillInAMode(n, matrix);
                    break;

                case 'b':
                    FillInBMode(n, matrix);
                    break;

                case 'c':
                    FillInCMode(n, matrix);
                    break;

                case 'd':
                    FillInDMode(n, matrix);
                    break;

                default:
                    throw new NotImplementedException();
            }

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - 1; ++j)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }

                Console.WriteLine("{0}", matrix[i, n - 1]);
            }
        }

        public static void FillInAMode(int n, int[,] matrix)
        {
            int fillNumber = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    matrix[j, i] = ++fillNumber;
                }
            }
        }

        public static void FillInBMode(int n, int[,] matrix)
        {
            int fillNumber = 0;
            for (int i = 0; i < n; ++i)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        matrix[j, i] = ++fillNumber;
                    }
                }
                else
                {
                    for (int j = n - 1; j >= 0; --j)
                    {
                        matrix[j, i] = ++fillNumber;
                    }
                }
            }
        }

        public static void FillInCMode(int n, int[,] matrix)
        {
            int fillNumber = 0;

            for (int j = 0; j < n; ++j)
            {
                for (int i = 0; i <= j; ++i)
                {
                    matrix[n - 1 - j + i, i] = ++fillNumber;
                }
            }

            for (int j = 1; j < n; ++j)
            {
                for (int i = 0; i < n - j; ++i)
                {
                    matrix[i, i + j] = ++fillNumber;
                }
            }
        }

        public static void FillInDMode(int n, int[,] matrix)
        {
            int seedNumber = 0;
            int fillNumber = seedNumber;

            int l = 0, r = n - 1;

            for (int i = 0; i < n; ++i)
            {
                seedNumber = FillInDirection(n, matrix, l, r, Direction.Down, seedNumber);

                ++l;

                seedNumber = FillInDirection(n, matrix, l, r, Direction.Right, seedNumber);

                seedNumber = FillInDirection(n, matrix, l, r, Direction.Top, seedNumber);

                seedNumber = FillInDirection(n, matrix, l, r, Direction.Left, seedNumber);

                --r;

                if (fillNumber == seedNumber)
                {
                    break;
                }
            }
        }

        private static int FillInDirection(int n, int[,] matrix, int left, int right, Direction direction, int seedNumber)
        {
            switch (direction)
            {
                case Direction.Down:
                    for (int i = left; i <= right; ++i)
                    {
                        matrix[i, left] = ++seedNumber;
                    }

                    break;

                case Direction.Right:
                    for (int i = left; i <= right; ++i)
                    {
                        matrix[right, i] = ++seedNumber;
                    }

                    break;

                case Direction.Top:
                    for (int i = left; i <= right; ++i)
                    {
                        matrix[n - 1 - i, right] = ++seedNumber;
                    }

                    break;

                case Direction.Left:
                    for (int i = left; i < right; ++i)
                    {
                        matrix[left - 1, n - 1 - i] = ++seedNumber;
                    }

                    break;

                default:
                    break;
            }

            return seedNumber;
        }

        public static Direction GetNextDirection(Direction direction)
        {
            return (Direction)(((int)direction + 1 + NumberOfDirections) % NumberOfDirections);
        }

        public enum Direction
        {
            Down = 0,
            Right = 1,
            Top = 2,
            Left = 3
        }
    }
}
