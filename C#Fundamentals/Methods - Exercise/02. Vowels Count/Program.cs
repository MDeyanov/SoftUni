using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();

            int vowelCount = GetVowelsCount(text);
            Console.WriteLine(vowelCount);
        }

        private static int GetVowelsCount(string text)
        {
            int counter = 0;
            foreach (char letter in text)
            {
                if (letter == 'a' || letter == 'e' || letter == 'o' || letter == 'u' || letter == 'y' || letter == 'i')
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
