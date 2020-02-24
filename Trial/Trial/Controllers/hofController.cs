using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trial.Models;

namespace Trial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hofController : ControllerBase
    {
        // Class Attributes
        private readonly hallOfFameContext _context; // Define context according to class context

        // Class Constructor
        public hofController(hallOfFameContext context)
        {
            _context = context;

            if (_context.hallOfFames.Count() < 5)
            {
                _context.hallOfFames.AddRange(
                        new List<hallOfFame>()
                        {
                            new hallOfFame { Name = "Kobe", Team = "Lakers", Title = "MVP" },
                            new hallOfFame { Name = "Kevin Durrant", Team = "Warriors", Title = "MVP" },
                            new hallOfFame { Name = "Curry", Team = "Warriors", Title = "MVP" },
                            new hallOfFame { Name = "Bryant", Team = "Lakers", Title = "MVP" },
                            new hallOfFame { Name = "Jordan", Team = "Bulls", Title = "MVP" }
                        }
                    );
                _context.SaveChangesAsync();
            }
        }

        // GET: api/hof
        [HttpGet]
        public async Task<ActionResult<IEnumerable<hallOfFame>>> GethallOfFames()
        {
            return await _context.hallOfFames.ToListAsync();
        }

        // GET: api/hof/5
        [HttpGet("{id}")]
        public async Task<ActionResult<hallOfFame>> GethallOfFame(int id)
        {
            var hallOfFame = await _context.hallOfFames.FindAsync(id);

            if (hallOfFame == null)
            {
                return NotFound();
            }

            return hallOfFame;
        }

        // GET: api/hof/Title=MVP&Team=Lakers
        [HttpGet("Title={title}&Team={team}")]
        public async Task<ActionResult<IEnumerable<hallOfFame>>> GethallOfFameMultiParam(string team, string title)
        {
            var hallOfFame = await _context.hallOfFames.ToListAsync();

            var result = new List<hallOfFame>();

            foreach (var i in hallOfFame)
            {
                if (i.Team == team && i.Title == title)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        // PUT: api/hof/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PuthallOfFame(int id, hallOfFame hallOfFame)
        {
            if (id != hallOfFame.id)
            {
                return BadRequest();
            }

            _context.Entry(hallOfFame).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hallOfFameExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/hof
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<hallOfFame>> PosthallOfFame(hallOfFame hallOfFame)
        {
            _context.hallOfFames.Add(hallOfFame);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GethallOfFame", new { id = hallOfFame.id }, hallOfFame);
        }

        // DELETE: api/hof/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<hallOfFame>> DeletehallOfFame(int id)
        {
            var hallOfFame = await _context.hallOfFames.FindAsync(id);
            if (hallOfFame == null)
            {
                return NotFound();
            }

            _context.hallOfFames.Remove(hallOfFame);
            await _context.SaveChangesAsync();

            return hallOfFame;
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody]JsonPatchDocument<hallOfFame> value)
        {
            try
            {
                //nodes collection is an in memory list of nodes for this example
                var result = await _context.hallOfFames.FindAsync(id);

                if (result == null)
                {
                    return NotFound();
                }

                value.ApplyTo(result);//result gets the values from the patch request

                await _context.SaveChangesAsync();

                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        private bool hallOfFameExists(int id)
        {
            return _context.hallOfFames.Any(e => e.id == id);
        }
    }
}
