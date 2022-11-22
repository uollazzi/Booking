using Booking.DataContext;
using Booking.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioniController : ControllerBase
    {
        private readonly ILogger<PrenotazioniController> _logger;
        private readonly BookingContext _dc;

        public PrenotazioniController(ILogger<PrenotazioniController> logger, BookingContext dc)
        {
            _logger = logger;
            _dc = dc;
        }

        [HttpPost("verifica")]
        public async Task<ActionResult<bool>> Verifica(VerificaDisponibilitaModel model)
        {
            var dal = DateTimeOffset.FromUnixTimeSeconds(model.Dal).LocalDateTime;
            var al = DateTimeOffset.FromUnixTimeSeconds(model.Al).LocalDateTime;

            var struttura = await _dc.Strutture.AsNoTracking()
                                               .Include(x => x.Stanze!)
                                               .ThenInclude(x => x.Disponibilita!)
                                               .Include(x => x.Stanze!)
                                               .ThenInclude(x => x.Prenotazioni!)
                                               .SingleOrDefaultAsync(x => x.Id == model.StrutturaId);

            if (struttura == null) return NotFound("Struttura non trovata");

            try
            {
                // cerco se ci sono stanze prenotabili nella struttura
                // in base al periodo ed in base al numero di posti
                var stanzePrenotabili = struttura.Stanze!
                    .Where(x => x.Disponibilita!.Any(a => a.Dal <= dal && a.Al >= al) && x.Capienza >= model.NumeroPosti);

                // delle stanze di cui sopra
                // ritorno la prima disponibile
                // (cioè quella che ha tutte le prenotazioni che non si accavallano al periodo selezionato)
                var stanza = stanzePrenotabili.FirstOrDefault(x => x.Prenotazioni!.All(x => x.Dal >= al || x.Al <= dal));

                return stanza != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }            
        }
    }
}
