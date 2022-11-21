using Booking.DataContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.DataContext
{
    public class BookingContext : DbContext
    {
        public BookingContext()
        {

        }
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<Citta> Citta => Set<Citta>();
        public DbSet<Disponibilita> Disponibilita => Set<Disponibilita>();
        public DbSet<Prenotazione> Prenotazioni => Set<Prenotazione>();
        public DbSet<Stanza> Stanze => Set<Stanza>();
        public DbSet<Struttura> Strutture => Set<Struttura>();
        public DbSet<Utente> Utenti => Set<Utente>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=Booking;User Id=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Data Seed
            modelBuilder.Entity<Utente>().HasData(new Utente { Id = 1, Nome = "Admin", Cognome = "Supremo", Email = "admin@booking.com" });
            modelBuilder.Entity<Utente>().HasData(new Utente { Id = 2, Nome = "Giovanni", Cognome = "Rossi", Email = "giovanni.rossi@gmail.com" });
            modelBuilder.Entity<Utente>().HasData(new Utente { Id = 3, Nome = "Pietro", Cognome = "Verdi", Email = "pietro.verdi@gmail.com" });
            modelBuilder.Entity<Utente>().HasData(new Utente { Id = 4, Nome = "Luca", Cognome = "Bianchi", Email = "luca.bianchi@gmail.com" });
            modelBuilder.Entity<Utente>().HasData(new Utente { Id = 5, Nome = "Matteo", Cognome = "Neri", Email = "matteo.neri@gmail.com" });
            #endregion
        }
    }
}
