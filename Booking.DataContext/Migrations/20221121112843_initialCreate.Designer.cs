﻿// <auto-generated />
using System;
using Booking.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Booking.DataContext.Migrations
{
    [DbContext(typeof(BookingContext))]
    [Migration("20221121112843_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Booking.DataContext.Models.Citta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lat")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Long")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Stato")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Citta");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Disponibilita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Al")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dal")
                        .HasColumnType("datetime2");

                    b.Property<int>("StanzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StanzaId");

                    b.ToTable("Disponibilita");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Prenotazione", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Al")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dal")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroPersone")
                        .HasColumnType("int");

                    b.Property<int>("StanzaId")
                        .HasColumnType("int");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StanzaId");

                    b.HasIndex("UtenteId");

                    b.ToTable("Prenotazioni");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Stanza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capienza")
                        .HasColumnType("int");

                    b.Property<double>("CostoUnitario")
                        .HasColumnType("float");

                    b.Property<int>("StrutturaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StrutturaId");

                    b.ToTable("Stanze");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Struttura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CittaId")
                        .HasColumnType("int");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CittaId");

                    b.ToTable("Strutture");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Utenti");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cognome = "Supremo",
                            Email = "admin@booking.com",
                            Nome = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Cognome = "Rossi",
                            Email = "giovanni.rossi@gmail.com",
                            Nome = "Giovanni"
                        },
                        new
                        {
                            Id = 3,
                            Cognome = "Verdi",
                            Email = "pietro.verdi@gmail.com",
                            Nome = "Pietro"
                        },
                        new
                        {
                            Id = 4,
                            Cognome = "Bianchi",
                            Email = "luca.bianchi@gmail.com",
                            Nome = "Luca"
                        },
                        new
                        {
                            Id = 5,
                            Cognome = "Neri",
                            Email = "matteo.neri@gmail.com",
                            Nome = "Matteo"
                        });
                });

            modelBuilder.Entity("Booking.DataContext.Models.Disponibilita", b =>
                {
                    b.HasOne("Booking.DataContext.Models.Stanza", "Stanza")
                        .WithMany("Disponibilita")
                        .HasForeignKey("StanzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stanza");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Prenotazione", b =>
                {
                    b.HasOne("Booking.DataContext.Models.Stanza", "Stanza")
                        .WithMany("Prenotazioni")
                        .HasForeignKey("StanzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking.DataContext.Models.Utente", "Utente")
                        .WithMany("Prenotazioni")
                        .HasForeignKey("UtenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stanza");

                    b.Navigation("Utente");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Stanza", b =>
                {
                    b.HasOne("Booking.DataContext.Models.Struttura", "Struttura")
                        .WithMany("Stanze")
                        .HasForeignKey("StrutturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Struttura");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Struttura", b =>
                {
                    b.HasOne("Booking.DataContext.Models.Citta", "Citta")
                        .WithMany("Strutture")
                        .HasForeignKey("CittaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Citta");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Citta", b =>
                {
                    b.Navigation("Strutture");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Stanza", b =>
                {
                    b.Navigation("Disponibilita");

                    b.Navigation("Prenotazioni");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Struttura", b =>
                {
                    b.Navigation("Stanze");
                });

            modelBuilder.Entity("Booking.DataContext.Models.Utente", b =>
                {
                    b.Navigation("Prenotazioni");
                });
#pragma warning restore 612, 618
        }
    }
}
