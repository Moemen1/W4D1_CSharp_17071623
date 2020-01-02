using System;
using System.Collections.Generic;
using System.Text;

namespace W4D1_CSharp_17071623.Model
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string InstrumentNaam { get; set; }

        public List<Artiest> Artiesten { get; set; }
    }
}
