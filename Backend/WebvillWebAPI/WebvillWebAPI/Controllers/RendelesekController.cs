using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebvillWebAPI.Models;

namespace WebvillWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendelesekController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var context=new webvillContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Rendeleseks
                    .Include(f => f.TazonNavigation.KazonNavigation).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
