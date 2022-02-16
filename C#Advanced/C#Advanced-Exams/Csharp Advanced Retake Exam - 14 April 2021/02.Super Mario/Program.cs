using System;
using System.Linq;
namespace _02.Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int columLenght = 0;
            char[][] matrix = new char[rows][];
            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                columLenght = input.Length;
                matrix[row] = input;
                if (input.Contains('M'))
                {
                    marioRow = row;
                    marioCol = Array.IndexOf(input, 'M');
                }
            }
            bool isWon = false;
            matrix[marioRow][marioCol] = '-';
            while (true)
            {
                if (isWon)
                {
                    matrix[marioRow][marioCol] = '-';
                    break;
                }
                if (lives<=0)
                {
                    matrix[marioRow][marioCol] = 'X';
                    break;
                }
                var commands = Console.ReadLine().Split().ToArray();
                var enemyRow = int.Parse(commands[1]);
                var enemyCol = int.Parse(commands[2]);
                matrix[enemyRow][enemyCol] = 'B';
                var directions = commands[0];             
                switch (directions)
                {
                    case "W":
                        marioRow--;
                        lives--;
                        if (IsOutside(marioRow, marioCol, rows, columLenght))
                        {
                            marioRow++;
                        }
                        if (matrix[marioRow][marioCol]=='B')
                        {
                            lives -= 2;
                            matrix[marioRow][marioCol] = '-';
                        }
                        if (matrix[marioRow][marioCol]=='P')
                        {
                            isWon = true;
                        }
                        break;
                    case "S":
                        marioRow++;
                        lives--;
                        if (IsOutside(marioRow, marioCol, rows, columLenght))
                        {
                            marioRow--;
                        }
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;
                            matrix[marioRow][marioCol] = '-';
                        }
                        if (matrix[marioRow][marioCol] == 'P')
                        {
                            isWon = true;
                        }
                        break;
                    case "A":
                        marioCol--;
                        lives--;
                        if (IsOutside(marioRow, marioCol, rows, columLenght))
                        {
                            marioCol++;
                        }
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;
                            matrix[marioRow][marioCol] = '-';
                        }
                        if (matrix[marioRow][marioCol] == 'P')
                        {
                            isWon = true;
                        }
                        break;
                    case "D":
                        marioCol++;
                        lives--;
                        if (IsOutside(marioRow, marioCol, rows, columLenght))
                        {
                            marioCol--;
                        }
                        if (matrix[marioRow][marioCol] == 'B')
                        {
                            lives -= 2;
                            matrix[marioRow][marioCol] = '-';
                        }
                        if (matrix[marioRow][marioCol] == 'P')
                        {
                            isWon = true;
                        }
                        break;                        
                    default:
                        break;
                }
            }
            if (isWon)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
            }
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("",matrix[row]));
            }
        }

        private static bool IsOutside(int marioRow, int marioCol, int rows, int columLenght)
        {
            return marioRow < 0 || marioCol < 0 || marioRow >= rows || marioCol >= columLenght;
        }
    }
}
