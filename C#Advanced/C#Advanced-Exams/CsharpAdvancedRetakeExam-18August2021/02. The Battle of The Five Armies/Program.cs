using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._The_Battle_of_The_Five_Armies
{
    class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rows][];
            int armyIndexRow = 0;
            int armyIndexCol = 0;
            int mordorRow = 0;
            int mordorCol = 0;
            int columsLenght = 0;
            int rowssslenght = rows;
            for (int i = 0; i < rows; i++)
            {
                char[] input = Console.ReadLine().ToArray();
                columsLenght = input.Length;
                if (input.Contains('M'))
                {
                    mordorCol = Array.IndexOf(input, 'M');
                    mordorRow = i;
                }
                if (input.Contains('A'))
                {
                    armyIndexCol = Array.IndexOf(input, 'A');
                    armyIndexRow = i;
                }
                matrix[i] = input;
            }

            while (true)
            {
                if (IsWarWon(armyIndexRow, armyIndexCol, mordorRow, mordorCol, matrix))
                {
                    matrix[armyIndexRow][armyIndexCol] = '-';
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                    break;
                }
                if (armor <= 0)
                {
                    matrix[armyIndexRow][armyIndexCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyIndexRow};{armyIndexCol}.");
                    break;
                }
                string[] commands = Console.ReadLine().Split();
                string direction = commands[0];
                int orcsRow = int.Parse(commands[1]);
                int orcsCol = int.Parse(commands[2]);
                matrix[orcsRow][orcsCol] = 'O';



                int armyOldIndexRow = armyIndexRow;
                int armyOldIndexCol = armyIndexCol;
                switch (direction)
                {
                    case "up":
                        armyIndexRow--;
                        if (IsValidIndex(armyIndexRow, armyIndexCol, rowssslenght, columsLenght))
                        {
                            armyIndexRow = armyOldIndexRow;
                        }
                        armor--;
                        if (IsFighting(armyIndexRow, armyIndexCol, matrix))
                        {
                            armor -= 2;
                            matrix[armyIndexRow][armyIndexCol] = '-';
                        }
                        matrix[armyOldIndexRow][armyOldIndexCol] = '-';
                        break;
                    case "down":
                        armyIndexRow++;
                        if (IsValidIndex(armyIndexRow, armyIndexCol, rowssslenght, columsLenght))
                        {
                            armyIndexRow = armyOldIndexRow;
                        }
                        armor--;
                        if (IsFighting(armyIndexRow, armyIndexCol, matrix))
                        {
                            armor -= 2;
                            matrix[armyIndexRow][armyIndexCol] = '-';
                        }
                        matrix[armyOldIndexRow][armyOldIndexCol] = '-';
                        break;
                    case "left":
                        armyIndexCol--;
                        if (IsValidIndex(armyIndexRow, armyIndexCol, rowssslenght, columsLenght))
                        {
                            armyIndexCol = armyOldIndexCol;
                        }
                        armor--;
                        if (IsFighting(armyIndexRow, armyIndexCol, matrix))
                        {
                            armor -= 2;
                            matrix[armyIndexRow][armyIndexCol] = '-';
                        }
                        matrix[armyOldIndexRow][armyOldIndexCol] = '-';
                        break;
                    case "right":
                        armyIndexCol++;
                        if (IsValidIndex(armyIndexRow, armyIndexCol, rowssslenght, columsLenght))
                        {
                            armyIndexCol = armyOldIndexCol;
                        }
                        armor--;
                        if (IsFighting(armyIndexRow, armyIndexCol, matrix))
                        {
                            armor -= 2;
                            matrix[armyIndexRow][armyIndexCol] = '-';
                        }
                        matrix[armyOldIndexRow][armyOldIndexCol] = '-';
                        break;
                    default:
                        break;
                }

            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }

        }



        private static bool IsWarWon(int armyIndexRow, int armyIndexCol, int mordorRow, int mordorCol, char[][] matrix)
        {
            return (matrix[armyIndexRow][armyIndexCol] == matrix[mordorRow][mordorCol]);
        }

        private static bool IsFighting(int armyIndexRow, int armyIndexCol, char[][] matrix)
        {
            return (matrix[armyIndexRow][armyIndexCol] == 'O');
        }

        private static bool IsValidIndex(int armyIndexRow, int armyIndexCol, int rowssslenght, int columsLenght)
        {
            int row = rowssslenght;
            int col = columsLenght;

            return armyIndexRow < 0 || armyIndexRow >= row || armyIndexCol < 0 || armyIndexCol >= col;
        }
    }
}
