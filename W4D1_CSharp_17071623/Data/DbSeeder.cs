using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W4D1_CSharp_17071623.Model;

namespace W4D1_CSharp_17071623.Data
{
    public class DbSeeder
    {
        public static void SeedDatabase(MyContext context)
        {
            if (context.Artiest.Any() || context.Popgroep.Any() || context.Instrument.Any())
            {
                return;
            }

            var Instrument = new Instrument[]
            {
                new Instrument{InstrumentNaam = "Piano"}, // ID 1
                new Instrument{InstrumentNaam = "Gitaar"}, // ID 2
                new Instrument{InstrumentNaam = "Saxofoon"}, // ID 3
                new Instrument{InstrumentNaam = "Drum"} // ID 4
            };

            foreach (Instrument i in Instrument)
            {
                context.Instrument.Add(i);
            }

            context.SaveChanges();

            var Popgroep = new Popgroep[]
            {
                new Popgroep{PopgroepNaam = "Popgroep1"}, // ID 1
                new Popgroep{PopgroepNaam = "Popgroep2"}, // ID 2
                new Popgroep{PopgroepNaam = "Popgroep3"}, // ID 3
                new Popgroep{PopgroepNaam = "Popgroep4"} // ID 4
            };

            foreach (Popgroep p in Popgroep)
            {
                context.Popgroep.Add(p);
            }

            context.SaveChanges();

            var Artiest = new Artiest[]
            {
                new Artiest{ArtiestNaam = "Jan", InstrumentId = 1, PopgroepId = 1 },
                new Artiest{ArtiestNaam = "Bob", InstrumentId = 2, PopgroepId = 1 },
                new Artiest{ArtiestNaam = "Jannice", InstrumentId = 3, PopgroepId = 1 },
                new Artiest{ArtiestNaam = "Carl", InstrumentId = 4, PopgroepId = 1 },

                new Artiest{ArtiestNaam = "Alice", InstrumentId = 2, PopgroepId = 2 },
                new Artiest{ArtiestNaam = "Dominique", InstrumentId = 1, PopgroepId = 2 },
                new Artiest{ArtiestNaam = "Sara", InstrumentId = 4, PopgroepId = 2 },


                new Artiest{ArtiestNaam = "John", InstrumentId = 3, PopgroepId = 3 },

                new Artiest{ArtiestNaam = "Will", InstrumentId = 4, PopgroepId = 4 },
            };

            foreach (Artiest a in Artiest)
            {
                context.Artiest.Add(a);
            }

            context.SaveChanges();
        }
    }
}
