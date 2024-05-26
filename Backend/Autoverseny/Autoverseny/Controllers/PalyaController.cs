using Autoverseny.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autoverseny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalyaController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get (int id)
        {
            var context = new versenyContext();
            try
            {
                return StatusCode(StatusCodes.Status200OK, context.Palyas.Where(f => f.Id == id).ToList());
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post (Palya palya)
        {
            var context=new versenyContext();
            try
            {
                context.Palyas.Add(palya);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Új pálya felvisele sikeres!");
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put (Palya palya) 
        {
            var context = new versenyContext();
            try
            {
                context.Palyas.Update(palya);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, "Módosítás sikeres.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status200OK);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context = new versenyContext();
            try
            {
                Palya palya = new Palya();
                palya.Id = id;
                context.Palyas.Remove(palya);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);

            }
        }
    }
}
