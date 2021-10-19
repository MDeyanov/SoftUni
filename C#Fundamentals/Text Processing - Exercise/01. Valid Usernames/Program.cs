using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ").ToArray();
            
            for (int i = 0; i < input.Length; i++)
            {
                char[] chars = input[i].ToCharArray();
                bool exit = false;
                bool validLenght = chars.Length >= 3 && chars.Length <= 16;
                for (int j = 0; j < chars.Length; j++)
                {
                    char x = chars[j];
                    if (!char.IsLetterOrDigit(x) && (x != '-') && (x != '_'))
                    {
                        exit = true;
                        break;
                    }

                }
                if (!exit && validLenght)
                {
                    string result = new string(chars);
                    Console.WriteLine(result);
                    
                }

            }
        }
    }
}
