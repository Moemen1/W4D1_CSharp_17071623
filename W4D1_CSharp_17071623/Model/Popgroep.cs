using System;
using System.Collections.Generic;
using System.Text;

namespace W4D1_CSharp_17071623.Model
{
    public class Popgroep
    {
        public int PopgroepId { get; set; }
        public string PopgroepNaam { get; set; }

        public List<Artiest> Artiesten { get; set; }
    }
}
