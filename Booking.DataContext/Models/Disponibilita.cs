using System.ComponentModel.DataAnnotations;

namespace Booking.DataContext.Models
{
    public class Disponibilita
    {
        public int Id { get; set; }

        [Required]
        public Stanza? Stanza { get; set; }

        [Required]
        public DateTime Dal { get; set; }

        [Required]
        public DateTime Al { get; set; }
    }
}
