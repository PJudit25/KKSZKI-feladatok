using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermekekController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context = new adatbazis2Context();
            try
            {
                //return Ok(context.Termekeks.ToList());
                return StatusCode(StatusCodes.Status200OK,context.Termekeks.Where(f=>f.Id==id).ToList());
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Termekek termek)
        {
            var context = new adatbazis2Context();
            try
            {
                context.Termekeks.Add(termek);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Új teermék sikeresen rögzítve.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Termekek termek)
        {
            var context=new adatbazis2Context();
            try
            {
                context.Termekeks.Update(termek);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, "Termék sikeresen módostva.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "A módosítás nem sikerült");
            }
        }


    }
}
