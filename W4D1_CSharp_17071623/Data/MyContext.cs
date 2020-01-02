using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using W4D1_CSharp_17071623.Model;

namespace W4D1_CSharp_17071623.Data
{
    public class MyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=W4D1CSharp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtiestInstrument>()
                .HasKey(a => new { a.ArtiestId, a.InstrumentId});

            modelBuilder.Entity<ArtiestInstrument>()
                .HasOne(a => a.Artiest)
                .WithMany(aa => aa.Instrumenten)
                .HasForeignKey(f => f.ArtiestId);

            modelBuilder.Entity<ArtiestInstrument>()
               .HasOne(a => a.Instrument)
               .WithMany(aa => aa.Artiesten)
               .HasForeignKey(f => f.InstrumentId);

            modelBuilder.Entity<Artiest>()
                .HasOne(p => p.Popgroep)
                .WithMany(a => a.Artiesten);
        }
        

        public DbSet<Artiest> Artiest { get; set; }
        public DbSet<ArtiestInstrument> ArtiestInstrument { get; set; }
        public DbSet<Instrument> Instrument { get; set; }
        public DbSet<Popgroep> Popgroep { get; set; }
    }
}
