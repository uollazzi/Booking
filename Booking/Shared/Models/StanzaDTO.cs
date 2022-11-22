using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Shared.Models
{
    public class StanzaDTO
    {
        public int Capienza { get; set; }
        public double CostoUnitario { get; set; }
        public List<DisponibilitaDTO> Disponibilita { get; set; } = new List<DisponibilitaDTO>();
    }
}
