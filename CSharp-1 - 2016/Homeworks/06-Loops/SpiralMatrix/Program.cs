namespace SpiralMatrix
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int[][] matrix = new int[input][];
            for (int i = 0; i < input; ++i)
            {
                matrix[i] = new int[input];
            }

            int currentRow = 0;
            int currentCol = 0;
            string direction = "right";
            for (int i = 0; i < input * input; i++)
            {
                switch (direction)
                {
                    case "right":
                        if (currentCol == input || matrix[currentRow][currentCol] != 0)
                        {
                            direction = "down";
                            currentCol--;
                            currentRow++;
                            if (i < input * input - 1)
                            {
                                i--;
                            }
                            else
                            {
                                matrix[currentRow][currentCol] = i + 1;
                            }
                        }
                        else
                        {
                            matrix[currentRow][currentCol] = i + 1;
                            currentCol++;
                        }

                        break;

                    case "down":
                        if (currentRow == input || matrix[currentRow][currentCol] != 0)
                        {
                            direction = "left";
                            currentCol--;
                            currentRow--;
                            if (i < input * input - 1)
                            {
                                i--;
                            }
                            else
                            {
                                matrix[currentRow][currentCol] = i + 1;
                            }
                        }
                        else
                        {
                            matrix[currentRow][currentCol] = i + 1;
                            currentRow++;
                        }
                        break;

                    case "left":
                        if (currentCol < 0 || matrix[currentRow][currentCol] != 0)
                        {
                            direction = "up";
                            currentRow--;
                            currentCol++;
                            if (i < input * input - 1)
                            {
                                i--;
                            }
                            else
                            {
                                matrix[currentRow][currentCol] = i + 1;
                            }
                        }
                        else
                        {
                            matrix[currentRow][currentCol] = i + 1;
                            currentCol--;
                        }
                        break;

                    case "up":
                        if (currentRow < 1 || matrix[currentRow][currentCol] != 0)
                        {
                            direction = "right";
                            currentCol++;
                            currentRow++;
                            if (i < input * input - 1)
                            {
                                i--;
                            }
                            else
                            {
                                matrix[currentRow][currentCol] = i + 1;
                            }
                        }
                        else
                        {
                            matrix[currentRow][currentCol] = i + 1;
                            currentRow--;
                        }
                        break;
                }
            }

            for (int row = 0; row < input; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}