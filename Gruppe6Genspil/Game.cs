using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    public class Game
    {

        public string Name { get; set; }

        public string Genre { get; set; }

        public int MaxPlayers { get; set; }

        public int MinPlayers { get; set; }

        public int AgeRating { get; set; }

        public string Variant { get; set; }

        public List<GameCopy> Copies { get; set; } = new List<GameCopy>();

        public Game(string name, string genre, int maxPlayers, int minPlayers, int ageRating, string variant)
        {
            Name = name;
            Genre = genre;
            MaxPlayers = maxPlayers;
            MinPlayers = minPlayers;
            AgeRating = ageRating;
            Variant = variant;
        }

        public override string ToString()
        {
            return $"GAME:{Name},{Genre},{MaxPlayers},{MinPlayers},{AgeRating},{Variant}";

        }

        public static Game FromString(string data)
        {
            string stripped = data.Substring(5);
            string[] parts = data.Split(',');
            return new Game(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), parts[5]);
        }
    }

}
