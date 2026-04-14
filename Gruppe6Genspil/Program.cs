namespace Gruppe6Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage("GameDatabase.txt");
            RequestStorage requestStorage = new RequestStorage("RequestDatabase.txt");
            Menu menu = new Menu(storage, requestStorage);
            storage.GiveIdToCopies();
            storage.GivePriceToCopies();
            menu.Start();
        }
    }
}
