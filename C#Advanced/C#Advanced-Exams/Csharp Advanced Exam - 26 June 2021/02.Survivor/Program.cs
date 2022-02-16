using System;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] matrix = new string[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                matrix[i] = input;
                
            }
            int playerTokens = 0;
            int oponentTokens = 0;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Gong")
                {
                    break;
                }
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
               
                if (commands[0] == "Find")
                {
                    if (!IsOutSide(matrix, row, col, rows))
                    {
                        if (matrix[row][col] == "T")
                        {
                            playerTokens++;
                            matrix[row][col] = "-";
                        }
                    }
                }
                else if (commands[0] == "Opponent")
                {
                    string direction = commands[3];
                    if (!IsOutSide(matrix, row, col, rows))
                    {
                        if (matrix[row][col] == "T")
                        {
                            oponentTokens++;
                            matrix[row][col] = "-";
                        }
                        switch (direction)
                        {
                            case "up":
                                for (int i = 0; i < 3; i++)
                                {
                                    row--;
                                    if (IsOutSide(matrix, row, col, rows))
                                    {
                                        row++;
                                        break;
                                    }
                                    if (matrix[row][col] == "T")
                                    {
                                        oponentTokens++;
                                        matrix[row][col] = "-";
                                    }
                                }
                                break;
                            case "down":
                                for (int i = 0; i < 3; i++)
                                {
                                    row++;
                                    if (IsOutSide(matrix, row, col, rows))
                                    {
                                        row--;
                                        break;
                                    }
                                    if (matrix[row][col] == "T")
                                    {
                                        oponentTokens++;
                                        matrix[row][col] = "-";
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 0; i < 3; i++)
                                {
                                    col--;
                                    if (IsOutSide(matrix, row, col, rows))
                                    {
                                        col++;
                                        break;
                                    }
                                    if (matrix[row][col] == "T")
                                    {
                                        oponentTokens++;
                                        matrix[row][col] = "-";
                                    }
                                }
                                break;
                            case "right":
                                for (int i = 0; i < 3; i++)
                                {
                                    col++;
                                    if (IsOutSide(matrix, row, col, rows))
                                    {
                                        col--;
                                        break;
                                    }
                                    if (matrix[row][col] == "T")
                                    {
                                        oponentTokens++;
                                        matrix[row][col] = "-";
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }                
            }
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(string.Join(" ",matrix[i]));
            }
            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");
        }

        private static bool IsOutSide(string[][] matrix, int row, int col, int rows)
        {
            return row < 0 || row >= rows || col < 0 || col >= matrix[row].Length;
        }
    }
}
