using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumindoAPIJoker
{
    public class Piada
    {
        public bool error { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string joke { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public Marcador flags { get; set; }
        public int id { get; set; }
        public string lang { get; set; }
    }
}
