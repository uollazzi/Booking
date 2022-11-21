using System.ComponentModel.DataAnnotations;

namespace Booking.DataContext.Models
{
    public class Utente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Cognome { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Prenotazione>? Prenotazioni { get; set; }
    }
}
