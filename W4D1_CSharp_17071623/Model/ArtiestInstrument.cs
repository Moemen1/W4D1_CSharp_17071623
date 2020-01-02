using System;
using System.Collections.Generic;
using System.Text;

namespace W4D1_CSharp_17071623.Model
{
    public class ArtiestInstrument
    {
        public int ArtiestId { get; set; }
        public virtual Artiest Artiest { get; set; }

        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}
