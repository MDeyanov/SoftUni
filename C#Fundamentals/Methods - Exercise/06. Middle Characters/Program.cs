using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            Console.WriteLine(GetMidCharacter(word));
        }

        static string GetMidCharacter(string word)
        {
            int lenght = word.Length;
            string result = "";
            if (lenght % 2 == 1)
            {
                result = word[word.Length / 2].ToString();
            }
            else
            {
                result = word[word.Length / 2 - 1].ToString() + word[word.Length / 2].ToString();
            }
            return result;
        }
    }
}
