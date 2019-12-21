﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using W4D1_CSharp_17071623;

namespace W4D1_CSharp_17071623.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("W4D1_CSharp_17071623.Artiest", b =>
                {
                    b.Property<int>("ArtiestId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArtiestNaam");

                    b.Property<int>("InstrumentId");

                    b.Property<int>("PopgroepId");

                    b.HasKey("ArtiestId");

                    b.HasIndex("InstrumentId");

                    b.HasIndex("PopgroepId");

                    b.ToTable("Artiest");
                });

            modelBuilder.Entity("W4D1_CSharp_17071623.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InstrumentNaam");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("W4D1_CSharp_17071623.Popgroep", b =>
                {
                    b.Property<int>("PopgroepId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PopgroepNaam");

                    b.HasKey("PopgroepId");

                    b.ToTable("Popgroep");
                });

            modelBuilder.Entity("W4D1_CSharp_17071623.Artiest", b =>
                {
                    b.HasOne("W4D1_CSharp_17071623.Instrument", "Instrument")
                        .WithMany("Artiesten")
                        .HasForeignKey("InstrumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("W4D1_CSharp_17071623.Popgroep", "Popgroep")
                        .WithMany("Artiesten")
                        .HasForeignKey("PopgroepId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}