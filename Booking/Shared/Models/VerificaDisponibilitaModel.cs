using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Shared.Models
{
    public class VerificaDisponibilitaModel
    {
        public long Dal { get; set; } // epoch
        public long Al { get; set; } // epoch
        public int NumeroPosti { get; set; }
        public int StrutturaId { get; set; }
    }
}
