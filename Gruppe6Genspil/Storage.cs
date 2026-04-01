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


    }
}
