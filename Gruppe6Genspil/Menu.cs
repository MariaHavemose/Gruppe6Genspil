using Gruppe6Genspil;
using System;
using System.Collections.Generic;
using System.Text;

public class Menu
{
    private Storage _storage;
    private RequestStorage _requestStorage;
    public Menu(Storage storage, RequestStorage requestStorage)
    {
        _storage = storage;
        _requestStorage = requestStorage;
    }
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Lagerstyringssystem ===");
            Console.WriteLine("1. Vis lager");
            Console.WriteLine("2. Søg efter spil");
            Console.WriteLine("3. Tilføj spil");
            Console.WriteLine("4. Slet spil");
            Console.WriteLine("5. Registrer forespørgsel");
            Console.WriteLine("6. Vis forespørgsler");
            Console.WriteLine("7. Afslut program");
            Console.Write("Vælg menu punkt: ");
            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    _storage.WriteAllGames();
                    break;
                case "2":
                    SearchGameMenu();
                    break;
                case "3":
                    AddGameMenu();
                    break;
                case "4":
                    AddRequestMenu();
                    break;
                case "5":
                    _requestStorage.ShowRequests();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Ugyldigt valg!");
                    break;
            }
            Console.WriteLine("\nTryk en tast for at fortsætte...");
            Console.ReadKey();
        }
    }
    private void SearchGameMenu()
    {
        Console.WriteLine("=== Søg efter spil ===");
        SearchCriteria criteria = new SearchCriteria();
        Console.Write("Navn (eller del af navn): ");
        criteria.Name = Console.ReadLine();
        Console.Write("Genre: ");
        criteria.Genre = Console.ReadLine();
        Console.Write("Stand: ");
        criteria.Condition = Console.ReadLine();
        Console.Write("Minpris: ");
        if (double.TryParse(Console.ReadLine(), out double minP))
            criteria.MinPrice = minP;
        Console.Write("Maxpris: ");
        if (double.TryParse(Console.ReadLine(), out double maxP))
            criteria.MaxPrice = maxP;
        Console.Write("Minimum spillere: ");
        if (int.TryParse(Console.ReadLine(), out int minPl))
            criteria.MinPlayers = minPl;
        Console.Write("Maksimum spillere: ");
        if (int.TryParse(Console.ReadLine(), out int maxPl))
            criteria.MaxPlayers = maxPl;
        var results = _storage.SearchGame(criteria);
        Console.WriteLine("\n--- Resultat ---\n");
        if (results.Count == 0)
        {
            Console.WriteLine("Ingen spil fundet.");
        }
        else
        {
            foreach (var game in results)
            {
                Console.WriteLine(game);
            }
        }
    }
    private void AddGameMenu()
    {
        Console.Write("Spil navn: ");
        string name = Console.ReadLine();
        Console.Write("Genre: ");
        string genre = Console.ReadLine();
        Console.Write("Maks spillere: ");
        int maxplayers = int.Parse(Console.ReadLine());
        Console.Write("Min spillere: ");
        int minplayers = int.Parse(Console.ReadLine());
        Console.Write("Aldersgrænse: ");
        int ageRating = int.Parse(Console.ReadLine());
        Console.Write("Variant: ");
        string variant = Console.ReadLine();
        Game game = new Game(name, genre, maxplayers, minplayers, ageRating, variant);
        _storage.AddGame(game);
    }
    private void AddRequestMenu()
    {
        Console.Write("Kundens navn: ");
        string customer = Console.ReadLine();
        Console.Write("Ønsket spil: ");
        string game = Console.ReadLine();
        Console.Write("Kommentar: ");
        string comment = Console.ReadLine();
        Request req = new Request(customer, game, comment);
        _requestStorage.AddRequest(req);
    }
}