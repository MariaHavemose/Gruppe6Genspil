using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    public class GameCopy
    {

        public string Condition { get; set; }
        public double Price { get; set; }

        public CopyStatus Reserved { get; set; }

        public string ReservedBy { get; set; }

        public int IdNumber { get; set; }


        public GameCopy(string condition, double price, CopyStatus status, int idNumber)
        {
            Condition = condition;
            Price = price;
            Reserved = status;
            ReservedBy = null;
            IdNumber = idNumber;
        }

        public override string ToString()
        {

            return $"COPY:{Condition},{Price},{Reserved},{ReservedBy},{IdNumber}";

        }

        public static GameCopy FromString(string data)
        {
            string stripped = data.Substring(5);
            string[] parts = stripped.Split(',');
            int idNumber = parts.Length > 4 ? int.Parse(parts[4]) : 0;
            return new GameCopy(parts[0], double.Parse(parts[1]), Enum.Parse<CopyStatus>(parts[2]), idNumber)
            {
                ReservedBy = parts[3]
            };
        }

        public static double GetPriceFromCondition(string condition)
        {
            switch (condition)
            {
                case "Helt ny":
                case "Ikke åbnet":
                    return 500;
                case "God stand":
                case "Lidt skrammet":
                case "Lettere ridset":
                    return 300;
                case "Lidt slidt":
                case "Skadet på hjørne ellers fin stand":
                    return 150;
                case "Kan måske reddes":
                    return 50;
                case "Til reparation":
                    return 0;   
                default:
                    return 0; // Pris sættes manuelt til 0 hvis ingen match
            }
        }


    }
}
