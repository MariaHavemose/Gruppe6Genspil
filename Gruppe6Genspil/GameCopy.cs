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

        public GameCopy(string condition, double price, CopyStatus status)
        {
            Condition = condition;
            Price = price;
            Reserved = status;
            ReservedBy = null;
        }

        public override string ToString()
        {
            return $"COPY:{Condition},{Price},{Reserved},{ReservedBy}";
        }

        public static GameCopy FromString(string data)
        {
            string stripped = data.Substring(5);
            string[] parts = data.Split(',');
            return new GameCopy(parts[0], double.Parse(parts[1]), Enum.Parse<CopyStatus>(parts[2]))
            {
                ReservedBy = parts[3]
            }
        }
    }
}
