using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phrase = new[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product."
            };
            string[] events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };
            string[] author = new[]
            {
                 "Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva", "Annie",
                    "Eva"

            };
            string[] city = new[]
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            int n = int.Parse(Console.ReadLine());
            Random random = new Random();


            for (int i = 0; i < n; i++)
            {
                int phraseIdx = random.Next(0, phrase.Length);
                int evetsIdx = random.Next(0, events.Length);
                int authorIdx = random.Next(0, author.Length);
                int cityIdx = random.Next(0, city.Length);
                string template = $"{phrase[phraseIdx]} {events[evetsIdx]} {author[authorIdx]} - {city[cityIdx]}";
                Console.WriteLine(template);
            }
        }
    }
}
