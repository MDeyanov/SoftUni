using System;
using System.Linq;
namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[][] matrix = new char[rows][];
            int playerRow = -1;
            int playerCol = -1;
            int columLenght = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                columLenght = input.Length;
                matrix[row] = input;
                if (input.Contains('f'))
                {
                    playerRow = row;
                    playerCol = Array.IndexOf(input, 'f');
                }
            }
            bool isWon = false;
            int count = 0;
            while (true)
            {
                if (count==columLenght-1)
                {
                    matrix[playerRow][playerCol] = 'f';
                    break;
                }
                string commands = Console.ReadLine();
                count++;
                
                switch (commands)
                {
                    case "up":
                        matrix[playerRow][playerCol] = '-';
                        playerRow--;
                        if (IsOutside(playerRow, playerCol, rows, columLenght))
                        {
                            playerRow = rows-1;
                        }
                        if (matrix[playerRow][playerCol]=='T')
                        {
                            playerRow++;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerRow--;
                            if (IsOutside(playerRow, playerCol, rows, columLenght))
                            {
                                playerRow = rows - 1;
                            }
                        }
                        break;
                    case "down":
                        matrix[playerRow][playerCol] = '-';
                        playerRow++;
                        if (IsOutside(playerRow, playerCol, rows, columLenght))
                        {
                            playerRow = 0;
                        }
                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerRow++;
                            if (IsOutside(playerRow, playerCol, rows, columLenght))
                            {
                                playerRow = rows - 1;
                            }
                        }
                        break;
                    case "right":
                        matrix[playerRow][playerCol] = '-';
                        playerCol++;
                        if (IsOutside(playerRow, playerCol, rows, columLenght))
                        {
                            playerCol = 0;
                        }
                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerCol++;
                            if (IsOutside(playerRow, playerCol, rows, columLenght))
                            {
                                playerCol = 0;
                            }
                        }
                        break;
                    case "left":
                        matrix[playerRow][playerCol] = '-';
                        playerCol--;
                        if (IsOutside(playerRow, playerCol, rows, columLenght))
                        {
                            playerCol = columLenght - 1;
                        }
                        if (matrix[playerRow][playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        if (matrix[playerRow][playerCol] == 'B')
                        {
                            playerCol--;
                            if (IsOutside(playerRow, playerCol, rows, columLenght))
                            {
                                playerCol = columLenght - 1;
                            }
                        }
                        break;                        
                    default:
                        break;
                }
                if (matrix[playerRow][playerCol]=='F')
                {
                    isWon = true;
                    matrix[playerRow][playerCol] = 'f';
                    break;
                }

            }
            if (isWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("",matrix[i]));
            }

            
        }

        private static bool IsOutside(int playerRow, int playerCol, int rows, int columLenght)
        {
            return playerRow < 0 || playerCol < 0 || playerRow >= rows || playerCol >= columLenght;
        }
    }
}
