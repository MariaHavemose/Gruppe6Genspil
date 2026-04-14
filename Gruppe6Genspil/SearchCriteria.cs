using System;
using System.Collections.Generic;
using System.Text;

namespace Gruppe6Genspil
{
    public class SearchCriteria
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int MaxPlayers { get; set; }
        public int MinPlayers { get; set; }
        public string Condition { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
        public string Variant { get; set; }
    }
}
