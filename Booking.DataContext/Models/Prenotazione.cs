using System.ComponentModel.DataAnnotations;

namespace Booking.DataContext.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }

        [Required]
        public virtual Utente? Utente { get; set; }

        [Required]
        public virtual Stanza? Stanza { get; set; }

        [Required]
        public DateTime Dal { get; set; }

        [Required]
        public DateTime Al { get; set; }

        [Required]
        public int NumeroPersone { get; set; }
    }
}
