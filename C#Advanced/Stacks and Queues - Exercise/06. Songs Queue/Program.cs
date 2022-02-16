using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> playList = new Queue<string>(songs);

            while (playList.Count > 0)
            {
                string commands = Console.ReadLine();
                if (commands.Contains("Play"))
                {
                    playList.Dequeue();
                }
                else if (commands.Contains("Add"))
                {
                    string songName = commands.Substring(4, commands.Length - 4);
                    if (playList.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        playList.Enqueue(songName);
                    }
                }
                else if (commands.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", playList));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
