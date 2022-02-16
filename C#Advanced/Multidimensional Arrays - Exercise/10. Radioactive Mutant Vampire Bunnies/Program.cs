using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];

                    if (rowData[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();
            bool isPlayerWon = false;
            bool isPlayerDead = false;
            foreach (char direction in directions)
            {
                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (direction)
                {
                    case 'U':
                        newPlayerRow--;
                        break;
                    case 'D':
                        newPlayerRow++;
                        break;
                    case 'L':
                        newPlayerCol--;
                        break;
                    case 'R':
                        newPlayerCol++;
                        break;
                }
                matrix[playerRow, playerCol] = '.';
                isPlayerWon = !IsValidCell(newPlayerRow, newPlayerCol, rows, cols);
                if (!isPlayerWon)
                {
                    if (matrix[newPlayerRow, newPlayerCol] == '.')
                    {
                        matrix[newPlayerRow, newPlayerCol] = 'P';
                    }
                    else if (matrix[newPlayerRow, newPlayerCol] == 'B')
                    {
                        isPlayerDead = true;
                    }
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }

                List<int[]> currBunnyIndex = GetBunnyIndexes(matrix);
                SpredBunnies(currBunnyIndex, matrix);
                if (matrix[playerRow, playerCol] == 'B')
                {
                    isPlayerDead = true;
                }

                if (isPlayerWon || isPlayerDead)
                {
                    break;
                }
            }
            PrintMatrix(matrix);
            string result = string.Empty;

            if (isPlayerWon)
            {
                result += "won:";
            }
            else
            {
                result += "dead:";
            }
            result += $" {playerRow} {playerCol}";
            Console.WriteLine(result);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void SpredBunnies(List<int[]> currBunnyIndex, char[,] matrix)
        {
            foreach (int[] bunnyIndexes in currBunnyIndex)
            {
                int bunnyRow = bunnyIndexes[0];
                int bunnyCol = bunnyIndexes[1];
                if (IsValidCell(bunnyRow - 1, bunnyCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow - 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow + 1, bunnyCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow + 1, bunnyCol] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol - 1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol - 1] = 'B';
                }

                if (IsValidCell(bunnyRow, bunnyCol + 1, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[bunnyRow, bunnyCol + 1] = 'B';
                }
            }
        }

        static List<int[]> GetBunnyIndexes(char[,] matrix)
        {
            List<int[]> bunnys = new List<int[]>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunnys.Add(new[] { row, col });
                    }
                }
            }
            return bunnys;
        }

        static bool IsValidCell(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }

    }
}
