using Fogado.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fogado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzobaController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var context=new fogadoContext();
            try
            {
                return StatusCode(StatusCodes.Status201Created, context.Szobaks.Where(f => f.Szazon == id).ToList());

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Post(Szobak szoba)
        {
            var context=new fogadoContext();
            try
            {
                context.Szobaks.Add(szoba);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status202Accepted, "Új szoba felvitele sikeres");
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status402PaymentRequired, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Szobak szoba)
        {
            var context=new fogadoContext();
            try
            {
                context.Szobaks.Update(szoba);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status203NonAuthoritative, "Módosítás sikeres");
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var context=new fogadoContext();
            try
            {
                Szobak szoba = new Szobak();
                szoba.Szazon = id;
                context.Szobaks.Remove(szoba);
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
