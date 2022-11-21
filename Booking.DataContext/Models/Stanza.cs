using System.ComponentModel.DataAnnotations;

namespace Booking.DataContext.Models
{
    public class Stanza
    {
        public int Id { get; set; }

        [Required]
        public virtual Struttura? Struttura { get; set; }

        [Required]
        public int Capienza { get; set; }

        [Required]
        public double CostoUnitario { get; set; }

        public virtual ICollection<Disponibilita>? Disponibilita { get; set; }

        public virtual ICollection<Prenotazione>? Prenotazioni { get; set; }
    }
}
