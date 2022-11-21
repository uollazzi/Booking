using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DataContext.Models
{
    public class Struttura
    {
        public int Id { get; set; }

        [Required]
        public virtual Citta? Citta { get; set; }

        [Required]
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Indirizzo { get; set; }

        public virtual ICollection<Stanza>? Stanze { get; set; }
    }
}
