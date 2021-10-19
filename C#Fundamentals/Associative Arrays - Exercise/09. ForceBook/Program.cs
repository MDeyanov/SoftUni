﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> membersBySide = new Dictionary<string, List<string>>();

            Dictionary<string, string> members = new Dictionary<string, string>();   
             

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains(" | "))
                {
                    string[] parts = command.Split(" | ");

                    string forceSide = parts[0];
                    string forceUser = parts[1];

                    if (members.ContainsKey(forceUser))
                    {
                        continue;
                    }

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }

                    membersBySide[forceSide].Add(forceUser);
                    members.Add(forceUser, forceSide);
                }
                else
                {
                    string[] parts = command.Split(" -> ");

                    string forceUser = parts[0];
                    string forceSide = parts[1];

                    if (!membersBySide.ContainsKey(forceSide))
                    {
                        membersBySide.Add(forceSide, new List<string>());
                    }

                    if (members.ContainsKey(forceUser))
                    {
                        string oldSide = members[forceUser];

                        membersBySide[oldSide].Remove(forceUser);
                        membersBySide[forceSide].Add(forceUser);
                        members[forceUser] = forceSide;
                    }
                    else
                    {
                        membersBySide[forceSide].Add(forceUser);
                        members.Add(forceUser, forceSide);
                    }

                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
            }
            Dictionary<string, List<string>> result = membersBySide
                .Where(s => s.Value.Count > 0)
                .OrderByDescending(s => s.Value.Count)
                .ThenBy(s => s.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                kvp.Value.Sort();
                foreach (var member in kvp.Value)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
