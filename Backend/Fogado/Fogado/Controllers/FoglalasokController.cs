using Fogado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fogado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoglalasokController : ControllerBase
    {
        [HttpGet("GetFull")]
        public IActionResult Get()
        {
            var context = new fogadoContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Foglalasoks
                    .Include(f => f.SzobaNavigation)
                    .Include(f => f.VendegNavigation).ToList());

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

    }
}
