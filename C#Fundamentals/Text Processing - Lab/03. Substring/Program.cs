using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstword = Console.ReadLine().ToLower();
            string phrase = Console.ReadLine();
            string yoyo = phrase.Substring(0);

            while (phrase.Contains(firstword))
            {
                phrase = phrase.Replace(firstword, "");
            }

            Console.WriteLine(phrase);
        }
    }
}
