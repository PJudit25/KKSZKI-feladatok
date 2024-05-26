using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebvillWebAPI.Models;

namespace WebvillWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriakController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context=new webvillContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK,context.Kategoriaks.Where(f=>f.Kazon==id).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Kategoriak kategoria)
        {
            var context=new webvillContext();
            try
            {
                context.Kategoriaks.Add(kategoria);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, "Új kategória sikeresen felvéve.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Kategoriak kategoria)
        {
            var context=new webvillContext();
            try
            {
                context.Kategoriaks.Update(kategoria);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, "Kategória adatai módosítva.");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context=new webvillContext();
            try
            {
                Kategoriak kategoria = new Kategoriak();
                kategoria.Kazon = id;
                context.Kategoriaks.Remove(kategoria);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status203NonAuthoritative, "Kategória sikeresen törölve.");
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}
