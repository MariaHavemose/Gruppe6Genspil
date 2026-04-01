using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gruppe6Genspil
{
    internal class Storage
    {
        public string FilePath { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();

        public Storage(string filePath)
        {
            FilePath = filePath;
            Games = LoadGamesFromFile();
        }

        public void SaveGamesToFile(List<Game> games)
        {
            using (StreamWriter sw = new StreamWriter(FilePath))
            {
                foreach (var game in games)
                {
                    sw.WriteLine(game.ToString());
                    foreach (var copy in game.Copies)
                    {
                        sw.WriteLine(copy.ToString());
                    }
                }
            }
        }

        public List<Game> LoadGamesFromFile()
        {
            List<Game> games = new List<Game>();

            using (StreamReader sr = new StreamReader(FilePath)) 
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("GAME:"))
                    {
                        games.Add(Game.FromString(line));
                    }
                    else if (line.StartsWith("COPY:"))
                    {
                        if (games.Count > 0)
                        {
                            games[games.Count - 1].Copies.Add(GameCopy.FromString(line));
                        }
                    }
                }
            }

            return games; 
        }

        public void HentAlleSpil()
        {
            foreach (var game in Games)
            {
                Console.WriteLine(game.ToString());
            }
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
            SaveGamesToFile(Games);
        }



    }
}
