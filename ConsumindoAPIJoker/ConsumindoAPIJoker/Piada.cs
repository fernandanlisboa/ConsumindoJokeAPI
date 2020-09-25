using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumindoAPIJoker
{
    public class Piada
    {
        public int formatVersion { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public Marcador flags { get; set; }
        public string lang { get; set; }
    }
}
