using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"(\@|\#)([A-Za-z]{3,})\1\1([A-Za-z]{3,})\1");
            Regex trimmed = new Regex(@"[A-Za-z]+");
            string text = Console.ReadLine();
            string newText = string.Empty;
            List<string> mirrors = new List<string>();

            int counter = 0;
            int totalCounter = 0;
            MatchCollection matches = regex.Matches(text);

            for (int i = 0; i < matches.Count; i++)
            {
                string word = matches[i].ToString();

                if (word.Contains("@"))
                {
                    word = word.Replace("@", " ");
                }
                else
                {
                    word = word.Replace("#", " ");
                }
                totalCounter++;
                string[] parts = word.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string reverse = string.Concat(parts[0].Reverse());
                string secWord = parts[1];
                if (reverse == secWord)
                {
                    counter++;
                    string rastoqnieto = parts[0] + " " + "<=>" + " " + secWord;
                    mirrors.Add(rastoqnieto);
                }
                ;
            }
            if (totalCounter == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{totalCounter} word pairs found!");
            }
            if (mirrors.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine("The mirror words are:");
            }
            Console.WriteLine(string.Join(", ", mirrors));
        }
    }
}
