using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public partial class Mines
    {
        const int boardRows = 5;
        const int boardColumns = 10;

        public class Score
        {
            string name;
            int points;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Points
            {
                get { return points; }
                set { points = value; }
            }

            public Score() { }

            public Score(string name, int points)
            {
                this.name = name;
                this.points = points;
            }
        }

        private static void PrintScore(List<Score> rate)
        {
            Console.WriteLine("\nScore:");
            if (rate.Count > 0)
            {
                for (int i = 0; i < rate.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes",
                        i + 1, rate[i].Name, rate[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty rating!\n");
            }
        }

        private static void RecalculateNextTurn(char[,] board,
            char[,] mines, int rowIndex, int columnIndex)
        {
            char numberOfMines = GetNumberOfMinesNearby(mines, rowIndex, columnIndex);
            mines[rowIndex, columnIndex] = numberOfMines;
            board[rowIndex, columnIndex] = numberOfMines;
        }

        private static void PrintBoardToConsole(char[,] board)
        {
            int boardRowsNumber = board.GetLength(0);
            int boardColumnsNumber = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < boardRowsNumber; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumnsNumber; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameBoard()
        {
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PopulateBoardWithMines()
        {

            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '-';
                }
            }

            List<int> minesList = new List<int>();
            while (minesList.Count < 15)
            {
                Random random = new Random();
                int randNumber = random.Next(50);
                if (!minesList.Contains(randNumber))
                {
                    minesList.Add(randNumber);
                }
            }

            foreach (int mine in minesList)
            {
                int rowIndex = (mine / boardColumns);
                int columnIndex = (mine % boardColumns);
                if (columnIndex == 0 && mine != 0)
                {
                    rowIndex--;
                    columnIndex = boardColumns;
                }
                else
                {
                    columnIndex++;
                }

                board[rowIndex, columnIndex - 1] = '*';
            }

            return board;
        }

        private static void CalculateNumberOfMinesNearby(char[,] board)
        {
            int boardRowsNumber = board.GetLength(0);
            int boardColumnsNumber = board.GetLength(1);

            for (int i = 0; i < boardRowsNumber; i++)
            {
                for (int j = 0; j < boardColumnsNumber; j++)
                {
                    if (board[i, j] != '*')
                    {
                        char numberOfMines = GetNumberOfMinesNearby(board, i, j);
                        board[i, j] = numberOfMines;
                    }
                }
            }
        }

        private static char GetNumberOfMinesNearby(char[,] board, int columnIndex, int rowIndex)
        {
            int totalNumber = 0;
            int boardRowsNumber = board.GetLength(0);
            int boardColumnsNumber = board.GetLength(1);

            if (columnIndex - 1 >= 0)
            {
                if (board[columnIndex - 1, rowIndex] == '*')
                {
                    totalNumber++;
                }
            }

            if (columnIndex + 1 < boardRowsNumber)
            {
                if (board[columnIndex + 1, rowIndex] == '*')
                {
                    totalNumber++;
                }
            }

            if (rowIndex - 1 >= 0)
            {
                if (board[columnIndex, rowIndex - 1] == '*')
                {
                    totalNumber++;
                }
            }

            if (rowIndex + 1 < boardColumnsNumber)
            {
                if (board[columnIndex, rowIndex + 1] == '*')
                {
                    totalNumber++;
                }
            }

            if ((columnIndex - 1 >= 0) && (rowIndex - 1 >= 0))
            {
                if (board[columnIndex - 1, rowIndex - 1] == '*')
                {
                    totalNumber++;
                }
            }

            if ((columnIndex - 1 >= 0) && (rowIndex + 1 < boardColumnsNumber))
            {
                if (board[columnIndex - 1, rowIndex + 1] == '*')
                {
                    totalNumber++;
                }
            }

            if ((columnIndex + 1 < boardRowsNumber) && (rowIndex - 1 >= 0))
            {
                if (board[columnIndex + 1, rowIndex - 1] == '*')
                {
                    totalNumber++;
                }
            }

            if ((columnIndex + 1 < boardRowsNumber) && (rowIndex + 1 < boardColumnsNumber))
            {
                if (board[columnIndex + 1, rowIndex + 1] == '*')
                {
                    totalNumber++;
                }
            }

            return char.Parse(totalNumber.ToString());
        }
    }
}