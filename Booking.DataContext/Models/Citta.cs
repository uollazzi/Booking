using System.ComponentModel.DataAnnotations;

namespace Booking.DataContext.Models
{
    public class Citta
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Stato { get; set; }

        [MaxLength(50)]
        public string? Lat { get; set; }

        [MaxLength(50)]
        public string? Long { get; set; }

        public virtual ICollection<Struttura>? Strutture { get; set; }
    }
}
