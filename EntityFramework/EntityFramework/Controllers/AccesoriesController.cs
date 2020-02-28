using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // path : /api/handphone
    public class AccesoriesController : ControllerBase
    {
        private readonly AccesoriesContext _context;

        //Constructor
        public AccesoriesController(AccesoriesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new { message = "success retrieve data", data = _context.accesories.ToList() });

        [HttpGet("{ID}")]
        public IActionResult GetbyId(int ID)
        {
            try
            {
                var result = _context.accesories.First(x => x.id == ID);
                return Ok(new { message = "success retrieve data", data = result });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Accesories accesories)
        {
            _context.Add(accesories);
            _context.SaveChanges();
            return Ok(new { message = "success add data", data = accesories });
        }

        [HttpDelete("{ID}")]
        public IActionResult DeletebyId(int ID)
        {
            try
            {
                var result = _context.accesories.First(x => x.id == ID);
                _context.accesories.Remove(result);
                return Ok(new { message = "success delete data", data = result });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
