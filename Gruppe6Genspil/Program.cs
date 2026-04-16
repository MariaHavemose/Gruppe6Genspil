namespace Gruppe6Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IdManager idManager = new IdManager();
            Storage storage = new Storage("GameDatabase.txt", idManager);
            RequestStorage requestStorage = new RequestStorage("RequestDatabase.txt");
            Menu menu = new Menu(storage, requestStorage, idManager);
            menu.Start();
        }
    }
}
