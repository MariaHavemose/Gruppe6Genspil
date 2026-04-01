using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    
    // REQUEST-KLASSEN (FOrespørgsel fra kunde)
    
    public class Request
    {
        // Kundens navn på den der forespørger spil
        public string CustomerName { get; set; }

        // Navnet på det spil kunden leder efter
        public string GameName { get; set; }

        // Ekstra kommentar fra kunden
        public string Comment { get; set; }

        
        // KONSTRUKTØR (Laver et nyt Request-objekt)
       
        public Request(string customerName, string gameName, string comment)
        {
            CustomerName = customerName;
            GameName = gameName;
            Comment = comment;
        }

        
        // VISNING AF REQUEST SOM TEKST
        
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