using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // path : /api/handphone
    public class HandphoneController : ControllerBase
    {
        private readonly HandphoneContext _context;

        //Constructor
        public HandphoneController(HandphoneContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new { message = "success retrieve data", data = _context.handphones.ToList() });

        [HttpGet("{ID}")]
        public IActionResult GetbyId(int ID)
        {
            try
            {
                var result = _context.handphones.First(x => x.id == ID);
                return Ok(new { message = "success retrieve data", data = result });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Handphone handphone)
        {
            _context.Add(handphone);
            _context.SaveChanges();
            return Ok(new { message = "success add data", data = handphone });
        }

        [HttpDelete("{ID}")]
        public IActionResult DeletebyId(int ID)
        {
            try
            {
                var result = _context.handphones.First(x => x.id == ID);
                _context.handphones.Remove(result);
                return Ok(new { message = "success delete data", data = result });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
