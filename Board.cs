using System;
using System.Collections.Generic;
using System.Linq;

namespace BoggleSolver
{
    public class Board
    {
        private static char[] RandomBoard()
        {
            string[] dice = {
                "AAEEGN", "ABBJOO", "ACHOPS", "AFFKPS",
                "AOOTTW", "CIMOTU", "DEILRX", "DELRVY",
                "DISTTY", "EEGHNW", "EEINSU", "EHRTVW",
                "EIOSST", "ELRTTY", "HIMNUA", "HLNNRZ"
            };

            char[] board = new char[16];
            List<int> diceNumbers = Enumerable.Range(0, 16).ToList();
            Random random = new Random();
            for (int i = 0; i <= 15; i++)
            {
                int x = random.Next(0, diceNumbers.Count());
                board[i] = dice[diceNumbers[x]][random.Next(0, 6)];
                diceNumbers.RemoveAt(x);
            }
            return board;
        }

        public static char[,] RandomBoardArray()
        {
            char[] board = RandomBoard();
            char[,] array = new char[4, 4];
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    int boardIndex = PointToInt(new Point(row, col));
                    array[row, col] = board[boardIndex];
                }
            }
            return array;
        }

        public static int PointToInt(Point point)
        {
            return ((point.row + 1) * (point.col + 1)) - 1;
        }

        public static void Print2DArray<T>(T[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int col = 0; col < array.GetLength(1); col++)
                {
                    Console.Write(array[row, col] + ". ");
                }
                Console.WriteLine();
            }
        }
    }
}
