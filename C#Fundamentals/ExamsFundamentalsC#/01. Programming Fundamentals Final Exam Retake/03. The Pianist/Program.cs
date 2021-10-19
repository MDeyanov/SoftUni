using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Pianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                string piece = inputs[0];
                string composer = inputs[1];
                string key = inputs[2];
                pieces.Add(piece, new List<string>());
                pieces[piece].Add(composer);
                pieces[piece].Add(key);
            }
            while (true)
            {
                string[] parts = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
                if (parts[0] == "Stop")
                {
                    break;
                }
                string command = parts[0];
                if (command == "Add")
                {
                    string piece = parts[1];
                    string composer = parts[2];
                    string key = parts[3];
                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new List<string>());
                        pieces[piece].Add(composer);
                        pieces[piece].Add(key);
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string piece = parts[1];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = parts[1];
                    string newKey = parts[2];
                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece][1] = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }
            Dictionary<string, List<string>> sorted = pieces.OrderBy(x => x.Key).ThenBy(x => x.Value[0]).ToDictionary(x => x.Key, x => x.Value);

            foreach (var piece in sorted)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}
