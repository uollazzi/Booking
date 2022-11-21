using Booking.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CittaController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<CittaModel>> GetAll()
        {
            return new List<CittaModel>();
        }
    }
}
