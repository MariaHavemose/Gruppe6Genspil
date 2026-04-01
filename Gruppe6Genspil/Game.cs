using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    internal class Game
    {

        public string Name { get; set; }
        public string Genre { get; set; }

        public int MaxPlayers { get; set; }

        public int MinPlayers { get; set; }

        public int AgeRating { get; set; }

        public List<GameCopy> Copies { get; set; } = new List<GameCopy>();

    }
}
