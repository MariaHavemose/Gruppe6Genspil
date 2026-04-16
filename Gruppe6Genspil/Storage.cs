using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Gruppe6Genspil
{
    public class Storage
    {
        public string FilePath { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
        private IdManager _idManager;
        public Storage(string filePath, IdManager idManager)
        {
            FilePath = filePath;
            _idManager = idManager;
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
                        int id = _idManager.GetNextId();
                        string trimmedLine = line.Replace("GAME:", "");
                        games.Add(Game.FromString(id, trimmedLine));
                    }
                    else if (line.StartsWith("COPY:"))
                    {
                        if (games.Count > 0)
                        {
                            string trimmedLine = line.Replace("COPY:", "");
                            games[games.Count - 1].Copies.Add(GameCopy.FromString(trimmedLine));
                        }
                    }
                }
            }
            return games; 
        }
        public void WriteAllGames()
        {
            int longestGameId = 0;
            int longestGameName = 0;
            int longestGameGenre = 0;
            int longestGameVariant = 0;
            int longestGameAgeRating = 0;
            int longestGameMaxPlayers = 0;
            int longestGameMinPlayers = 0;
            foreach (var game in Games)
            {
                if (game.Id.ToString().Length > longestGameId)
                    longestGameId = game.Id.ToString().Length;
                if (game.Name.Length > longestGameName)
                    longestGameName = game.Name.Length;
                if (game.Genre.Length > longestGameGenre)
                    longestGameGenre = game.Genre.Length;
                if (game.Variant.Length > longestGameVariant)
                    longestGameVariant = game.Variant.Length;
                if (game.AgeRating.ToString().Length > longestGameAgeRating)
                    longestGameAgeRating = game.AgeRating.ToString().Length;
                if (game.MaxPlayers.ToString().Length > longestGameMaxPlayers)
                    longestGameMaxPlayers = game.MaxPlayers.ToString().Length;
                if (game.MinPlayers.ToString().Length > longestGameMinPlayers)
                    longestGameMinPlayers = game.MinPlayers.ToString().Length;
            }
            Console.WriteLine("=== Spillager ===\n");
            foreach (var game in Games)
            {
                string gameIdCell = "ID: " + game.Id.ToString().PadRight(longestGameId);
                string gameNameCell = "Navn: " + game.Name.PadRight(longestGameName);
                string gameGenreCell = "Genre: " + game.Genre.PadRight(longestGameGenre);
                string gameVariantCell = "Variant: " + game.Variant.PadRight(longestGameVariant);
                string gameAgeRatingCell = "Aldersmærkning: " + game.AgeRating.ToString().PadRight(longestGameAgeRating);
                string gameMaxPlayersCell = "Maksimum spillere: " + game.MaxPlayers.ToString().PadRight(longestGameMaxPlayers);
                string gameMinPlayersCell = "Minimum spillere: " + game.MinPlayers.ToString().PadRight(longestGameMinPlayers);
                string gameCopyAmount = "Antal kopier: " + game.Copies.Count;
                Console.WriteLine(gameIdCell 
                    + " | " + gameNameCell 
                    + " | " + gameGenreCell 
                    + " | " + gameVariantCell 
                    + " | " + gameAgeRatingCell 
                    + " | " + gameMaxPlayersCell 
                    + " | " + gameMinPlayersCell 
                    + " | " + gameCopyAmount);
            }
        }
        public void AddGame(Game game)
        {
            Games.Add(game);
            SaveGamesToFile(Games);
        }

        // Sanna delete game test
        public void DeleteGame(int id)
        {
            Games.RemoveAll(x => x.Id == id);
            SaveGamesToFile(Games);
        }

        public List<Game> SearchGame(SearchCriteria criteria)
        {
            List<Game> results = new List<Game>();
            foreach (var game in Games)
            {
                if (
                (string.IsNullOrEmpty(criteria.Name) || game.Name.Contains(criteria.Name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(criteria.Genre) || game.Genre.Contains(criteria.Genre, StringComparison.OrdinalIgnoreCase)))
                {
                    results.Add(game);
                }
            }
            return results;
        }
    }
}
