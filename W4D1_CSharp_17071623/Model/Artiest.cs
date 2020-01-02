using System;
using System.Collections.Generic;
using System.Text;

namespace W4D1_CSharp_17071623.Model
{
    public class Artiest
    {
        public int ArtiestId { get; set; }
        public string ArtiestNaam { get; set; }

        public int? InstrumentId { get; set; }
        public List<ArtiestInstrument> Instrumenten { get; set; }

        public int PopgroepId { get; set; }
        public Popgroep Popgroep { get; set; }
    }
}
