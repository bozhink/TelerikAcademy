using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public partial class Mines
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] board = CreateGameBoard();
            char[,] mineField = PopulateBoardWithMines();
            List<Score> topPlayers = new List<Score>(6);
            int counter = 0;
            int rowIndex = 0;
            int columnIndex = 0;
            bool isDead = false;
            bool isNewGame = true;
            bool isWinner = false;
            const int maxScoreToWin = 35;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    PrintBoardToConsole(board);
                    isNewGame = false;
                }

                Console.Write("Daj red i kolona : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out rowIndex) &&
                        int.TryParse(command[2].ToString(), out columnIndex) &&
                        rowIndex < board.GetLength(0) && columnIndex < board.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintScore(topPlayers);
                        break;
                    case "restart":
                        board = CreateGameBoard();
                        mineField = PopulateBoardWithMines();
                        PrintBoardToConsole(board);
                        isDead = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (mineField[rowIndex, columnIndex] != '*')
                        {
                            if (mineField[rowIndex, columnIndex] == '-')
                            {
                                RecalculateNextTurn(board, mineField, rowIndex, columnIndex);
                                counter++;
                            }

                            if (maxScoreToWin == counter)
                            {
                                isWinner = true;
                            }
                            else
                            {
                                PrintBoardToConsole(board);
                            }
                        }
                        else
                        {
                            isDead = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }

                if (isDead)
                {
                    PrintBoardToConsole(mineField);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string name = Console.ReadLine();
                    Score score = new Score(name, counter);
                    if (topPlayers.Count < 5)
                    {
                        topPlayers.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < topPlayers.Count; i++)
                        {
                            if (topPlayers[i].Points < score.Points)
                            {
                                topPlayers.Insert(i, score);
                                topPlayers.RemoveAt(topPlayers.Count - 1);
                                break;
                            }
                        }
                    }

                    topPlayers.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topPlayers.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    PrintScore(topPlayers);

                    board = CreateGameBoard();
                    mineField = PopulateBoardWithMines();
                    counter = 0;
                    isDead = false;
                    isNewGame = true;
                }

                if (isWinner)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    PrintBoardToConsole(mineField);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score score = new Score(name, counter);
                    topPlayers.Add(score);
                    PrintScore(topPlayers);
                    board = CreateGameBoard();
                    mineField = PopulateBoardWithMines();
                    counter = 0;
                    isWinner = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }
    }
}
