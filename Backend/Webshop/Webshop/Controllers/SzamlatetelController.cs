using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzamlatetelController : ControllerBase
    {
        [HttpGet("GetFull")]
        public IActionResult Get()
        {
            var context = new adatbazis2Context();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Szamlatetels
                    .Include(f=>f.Szamlafej.Vevo)
                    .Include(f=>f.Termek).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context=new adatbazis2Context();
            try
            {
                Szamlatetel szamlatetel = new Szamlatetel();
                szamlatetel.Id = id;
                context.Szamlatetels.Remove(szamlatetel);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent, szamlatetel + " számlatétel sikeresen törölve.");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
