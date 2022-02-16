using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private readonly List<Player> roster;
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public Guild(string name, int capacity)
        {
            roster = new List<Player>();
            Name = name;
            Capacity = capacity;
        }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.FirstOrDefault(x => x.Name == name));
        }
        public void PromotePlayer(string name)
        {
            var player = roster.First(x => x.Name == name);
            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var player = roster.First(x => x.Name == name);
            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            var playerArray = roster.Where(x => x.Class == @class).ToArray();
            roster.RemoveAll(x => x.Class == @class);
            return playerArray;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
                sb.AppendLine($"Rank: {player.Rank}");
                sb.AppendLine($"Description: {player.Description}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
