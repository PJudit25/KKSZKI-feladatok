using KonyvtarakWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonyvtarakWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KonyvtarakController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context=new konyvtarakContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Konyvtaraks.ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("GetFull")]
        public IActionResult Get() 
        {
            var context = new konyvtarakContext();
            try
            {
                return StatusCode(StatusCodes.Status201Created, context.Konyvtaraks
                    .Include(f => f.Telepulesek.Megyek).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
