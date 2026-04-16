using Gruppe6Genspil;
using System;
using System.Collections.Generic;
using System.Text;

public class Menu
{
    private Storage _storage;
    private RequestStorage _requestStorage;
    private IdManager _idManager;
    public Menu(Storage storage, RequestStorage requestStorage, IdManager idManager)
    {
        _storage = storage;
        _requestStorage = requestStorage;
        _idManager = idManager;
    }
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Lagerstyringssystem ===");
            Console.WriteLine("1. Vis spillager");
            Console.WriteLine("2. Søg efter spil");
            Console.WriteLine("3. Tilføj spil");
            Console.WriteLine("4. Slet spil");
            Console.WriteLine("5. Registrer forespørgsel");
            Console.WriteLine("6. Vis forespørgsler");
            Console.WriteLine("7. Slet forespørgsel");
            Console.WriteLine("8. Afslut program");
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
                    DeleteGameMenu();
                    break;
                case "5":
                    AddRequestMenu();
                    break;
                case "6":
                    _requestStorage.ShowRequests();
                    break;
                case "7":
                    DeleteRequestMenu();
                    break;
                case "8":
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
        int id = _idManager.GetNextId();
        Console.WriteLine("=== Tilføj spil ===\n");
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
        Game game = new Game(id, name, genre, maxplayers, minplayers, ageRating, variant);
        _storage.AddGame(game);
    }
    private void DeleteGameMenu()
    {
        Console.WriteLine("=== Slet spil ===");
        Console.WriteLine("For at slette et spil, skal du indtaste dens ID. Du finder ID nummer for hvert spil under 'Spillager' i menuen.\n");
        Console.Write("Spil ID: ");
        int id = int.Parse(Console.ReadLine());
        _storage.DeleteGame(id);
        Console.WriteLine("\nSlettet spil med ID: " + id);
    }
    private void AddRequestMenu()
    {
        Console.WriteLine("=== Registrer forespørgsel ===\n");
        Console.Write("Kundens navn: ");
        string customer = Console.ReadLine();
        Console.Write("Ønsket spil: ");
        string game = Console.ReadLine();
        Console.Write("Kommentar: ");
        string comment = Console.ReadLine();
        Request req = new Request(customer, game, comment);
        _requestStorage.AddRequest(req);
    }

    // Sanna DeleteRequestMenu test
    private void DeleteRequestMenu()
    {
        Console.WriteLine("=== Slet forespørgsel ===");
        Console.WriteLine("For at slette en forespørgsel, skal du indtaste dens ID. Du finder ID nummer for hver forespørgsel under 'Vis forespørgsler' i menuen.");
        Console.WriteLine("- Tryk ENTER to gange uden at skrive noget for at komme tilbage til menuen.\n");
        Console.Write("Forespørgsel ID: ");
        int id = int.Parse(Console.ReadLine());
    }
}