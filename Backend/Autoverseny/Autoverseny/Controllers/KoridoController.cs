using Autoverseny.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autoverseny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoridoController : ControllerBase
    {
        [HttpGet("GetFull")]
        public IActionResult Get()
        {
            var context=new versenyContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Koridos
                    .Include(f => f.Palya)
                    .Include(f => f.Versenyzo.Csapat).ToList());

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
