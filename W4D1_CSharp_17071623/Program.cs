using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace W4D1_CSharp_17071623
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=W4D1CSharp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artiest>()
                .HasOne(i => i.Instrument)
                .WithMany(a => a.Artiesten);

            modelBuilder.Entity<Artiest>()
                .HasOne(p => p.Popgroep)
                .WithMany(a => a.Artiesten);
        }

        public DbSet<Artiest> Artiest { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<Popgroep> Popgroep { get; set; }
    }

    public class Artiest
    {
        public int ArtiestId { get; set; }
        public string ArtiestNaam { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }

        public int PopgroepId { get; set; }
        public Popgroep Popgroep { get; set; }
    }

    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string InstrumentNaam { get; set; }

        public List<Artiest> Artiesten { get; set; }
    }

    public class Popgroep
    {
        public int PopgroepId { get; set; }
        public string PopgroepNaam { get; set; }

        public List<Artiest> Artiesten { get; set; }
    }

    class Program
    {
        static void SeedDatabase(MyContext context)
        {
            if (context.Artiest.Any() || context.Popgroep.Any() || context.Instrument.Any())
            {
                return;
            }

            var Instrument = new Instrument[]
            {
                new Instrument{InstrumentNaam = "Piano"},
                new Instrument{InstrumentNaam = "Gitaar"},
                new Instrument{InstrumentNaam = "Saxofoon"},
                new Instrument{InstrumentNaam = "Drum"}
            };

            foreach (Instrument i in Instrument)
            {
                context.Instrument.Add(i);
            }

            context.SaveChanges();

            var Popgroep = new Popgroep[]
            {
                new Popgroep{PopgroepNaam = "Popgroep1"},
                new Popgroep{PopgroepNaam = "Popgroep2"},
                new Popgroep{PopgroepNaam = "Popgroep3"},
                new Popgroep{PopgroepNaam = "Popgroep4"}
            };

            foreach (Popgroep p in Popgroep)
            {
                context.Popgroep.Add(p);
            }

            context.SaveChanges();

            var Artiest = new Artiest[]
            {
                new Artiest{ArtiestNaam = "Jan", InstrumentId = 1, PopgroepId = 1 },
                new Artiest{ArtiestNaam = "Alice", InstrumentId = 2, PopgroepId = 2 },
                new Artiest{ArtiestNaam = "John", InstrumentId = 3, PopgroepId = 3 },
                new Artiest{ArtiestNaam = "Will", InstrumentId = 4, PopgroepId = 4 },
            };

            foreach (Artiest a in Artiest)
            {
                context.Artiest.Add(a);
            }

            context.SaveChanges();
        }

        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                SeedDatabase(context);

                foreach (Artiest a in context.Artiest
                                            .Include(i => i.Instrument)
                                            .Include(p => p.Popgroep))
                {
                    Console.WriteLine(String.Format("Auteurnaam: {0} | Instrument: {1} | Popgroep: {2}  "
                        , a.ArtiestNaam, a.Instrument.InstrumentNaam, a.Popgroep.PopgroepNaam));
                }
            }
        }
    }
}
