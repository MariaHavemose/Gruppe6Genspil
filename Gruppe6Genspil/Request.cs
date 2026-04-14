using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    // REQUEST-KLASSEN (Forespørgsel fra kunde)
    public class Request
    {
        public string CustomerName { get; set; }
        public string GameName { get; set; }
        public string Comment { get; set; }

        // KONSTRUKTØR (Laver et nyt Request-objekt)
        public Request(string customerName, string gameName, string comment)
        {
            CustomerName = customerName;
            GameName = gameName;
            Comment = comment;
        }

        // VISER REQUEST SOM TEKST
        public override string ToString()
        {
            return $"{CustomerName},{GameName},{Comment}";
        }
        public static Request FromString(string data)
        {
            string[] parts = data.Split(',');
            return new Request(parts[0], parts[1], parts[2]);
        }
    }
}