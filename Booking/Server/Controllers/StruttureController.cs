using Booking.DataContext;
using Booking.DataContext.Models;
using Booking.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Booking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StruttureController : ControllerBase
    {
        private readonly ILogger<StruttureController> _logger;
        private readonly BookingContext _dc;

        public StruttureController(ILogger<StruttureController> logger, BookingContext dc)
        {
            _logger = logger;
            _dc = dc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StrutturaModel>>> GetAll()
        {
            return new List<StrutturaModel>();
        }

        [HttpPost]
        public async Task<ActionResult<StrutturaModel>> Add(StrutturaDTO dto)
        {
            var citta = await _dc.Citta.SingleOrDefaultAsync(x => x.Id == dto.CittaId);

            if (citta == null) return NotFound("Città non trovata.");

            try
            {
                // inserisco la struttura
                var struttura = new Struttura
                {
                    Citta = citta,
                    Indirizzo = dto.Indirizzo,
                    Nome = dto.Nome,
                    Stanze = new List<Stanza>()
                };
                _dc.Strutture.Add(struttura);

                foreach (var s in dto.Stanze)
                {
                    struttura.Stanze.Add(new Stanza
                    {
                        Capienza = s.Capienza,
                        CostoUnitario = s.CostoUnitario,
                        Disponibilita = s.Disponibilita.Select(d => new Disponibilita
                        {
                            Dal = DateTimeOffset.FromUnixTimeSeconds(d.Dal).LocalDateTime,
                            Al = DateTimeOffset.FromUnixTimeSeconds(d.Al).LocalDateTime,
                        }).ToList()
                    });
                }

                await _dc.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok();
        }
    }
}
