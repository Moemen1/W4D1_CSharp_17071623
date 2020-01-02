using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W4D1_CSharp_17071623.Model;

namespace W4D1_CSharp_17071623.Data
{
    public class Queries
    {
        public static void ShowArtiest(MyContext context)
        {
            foreach (Artiest a in context.Artiest
                                         .Include(i => i.Instrument)
                                         .Include(p => p.Popgroep))
            {
                Console.WriteLine(String.Format("Auteurnaam: {0} | Instrument: {1} | Popgroep: {2}  "
                    , a.ArtiestNaam, a.Instrument.InstrumentNaam, a.Popgroep.PopgroepNaam));
            }
        }

        public static void ShowPopgroep(MyContext context, string PopgroepNaam)
        {
            var band = context.Popgroep
                              .Where(p => p.PopgroepNaam == PopgroepNaam)
                              .SelectMany(a => a.Artiesten).ToList();

            Console.Write(PopgroepNaam + " heeft de volgende artiesten: ");

            foreach (Artiest a in band)
            {
                if (a.Equals(band.Last())) // check laatste element
                {
                    Console.WriteLine(a.ArtiestNaam);
                }
                else
                {
                    Console.Write(a.ArtiestNaam + ", ");
                }
            }
        }

        public static void ShowWieInstrumentSpeelt(MyContext context, string instrumentNaam)
        {
            var spelers = context.Instrument
                .Include(instrument => instrument.Artiesten)
                    .ThenInclude(artiest => artiest.Popgroep)
                .Where(i => i.InstrumentNaam == instrumentNaam)
                .SelectMany(a => a.Artiesten)
                .ToList();

            Console.Write("Het instrument " + instrumentNaam + " wordt door de volgende mensen gespeeld: ");

            foreach (Artiest a in spelers)
            {
                if (a.Equals(spelers.Last()))
                {
                    Console.WriteLine(a.ArtiestNaam);
                }
                else
                {
                    Console.Write(a.ArtiestNaam + ", ");
                }
            }
        }

        public static void ShowBandsMetSaxofoonSpeler(MyContext context)
        {
            var ArtiestMetSaxofoon = context.Artiest
                .Where(a => a.Instrument.InstrumentNaam == "Saxofoon")
                .Select(b => b.Popgroep.PopgroepNaam).ToList();

            foreach (string s in ArtiestMetSaxofoon)
            {
                Console.WriteLine(s);
            }

        }

        public static void ShowGroteBands(MyContext context)
        {
            var groteBands = context.Popgroep.Where(p => p.Artiesten.Count >= 3).ToList();

            Console.WriteLine("Alle popgroepen met meer dan 3 artiesten: ");

            foreach (Popgroep p in groteBands)
            {
                // Explicit Loading
                context.Entry(p)
                    .Collection(b => b.Artiesten)
                    .Load();

                Console.Write(p.PopgroepNaam + ": ");

                foreach (Artiest artiest in p.Artiesten)
                {
                    if (artiest.Equals(p.Artiesten.Last()))
                        Console.WriteLine(artiest.ArtiestNaam);
                    else
                        Console.Write(artiest.ArtiestNaam + ", ");
                }

                Console.WriteLine("--------------------------------");
            }
        }

    }
}
