using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    internal class Storage
    {
        public string FilePath { get; set; }

        public Storage(string filePath)
        {
            FilePath = filePath; 
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


    }
}
