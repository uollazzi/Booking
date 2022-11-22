using Booking.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenotazioniController : ControllerBase
    {
        [HttpPost("verifica")]
        public async Task<ActionResult<bool>> Verifica(VerificaDisponibilitaModel model)
        {
            return true;
        }
    }
}
