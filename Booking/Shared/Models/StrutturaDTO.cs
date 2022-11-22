using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Shared.Models
{
    public class StrutturaDTO
    {
        public int CittaId { get; set; }
        public string? Nome { get; set; }
        public string? Indirizzo { get; set; }
        public List<StanzaDTO> Stanze { get; set; } = new List<StanzaDTO>();
    }
}
