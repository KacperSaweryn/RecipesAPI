using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngridientsController : ControllerBase
    {
        private readonly RecipesContext _context;

        public IngridientsController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/Ingridients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingridient>>> GetIngridient()
        {
          if (_context.Ingridient == null)
          {
              return NotFound();
          }
            return await _context.Ingridient.ToListAsync();
        }

        // GET: api/Ingridients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingridient>> GetIngridient(int id)
        {
          if (_context.Ingridient == null)
          {
              return NotFound();
          }
            var ingridient = await _context.Ingridient.FindAsync(id);

            if (ingridient == null)
            {
                return NotFound();
            }

            return ingridient;
        }

        // PUT: api/Ingridients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngridient(int id, Ingridient ingridient)
        {
            if (id != ingridient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingridient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngridientExists(id))
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

        // POST: api/Ingridients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingridient>> PostIngridient(Ingridient ingridient)
        {
          if (_context.Ingridient == null)
          {
              return Problem("Entity set 'RecipesContext.Ingridient'  is null.");
          }
            _context.Ingridient.Add(ingridient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngridient", new { id = ingridient.Id }, ingridient);
        }

        // DELETE: api/Ingridients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngridient(int id)
        {
            if (_context.Ingridient == null)
            {
                return NotFound();
            }
            var ingridient = await _context.Ingridient.FindAsync(id);
            if (ingridient == null)
            {
                return NotFound();
            }

            _context.Ingridient.Remove(ingridient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngridientExists(int id)
        {
            return (_context.Ingridient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
