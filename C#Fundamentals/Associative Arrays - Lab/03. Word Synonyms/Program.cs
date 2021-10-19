using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordsAndSynonims = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonim = Console.ReadLine();

                if (wordsAndSynonims.ContainsKey(word))
                {
                    wordsAndSynonims[word].Add(synonim);
                }
                else
                {
                    wordsAndSynonims.Add(word, new List<string>() { synonim });
                }
            }
            foreach (var key in wordsAndSynonims)
            {
                Console.WriteLine($"{key.Key} - {string.Join(", ", key.Value)}");
            }
        }
    }
}
