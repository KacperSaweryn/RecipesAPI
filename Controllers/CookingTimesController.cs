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
    public class CookingTimesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public CookingTimesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/CookingTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookingTime>>> GetCookingTime()
        {
          if (_context.CookingTime == null)
          {
              return NotFound();
          }
            return await _context.CookingTime.ToListAsync();
        }

        // GET: api/CookingTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookingTime>> GetCookingTime(int id)
        {
          if (_context.CookingTime == null)
          {
              return NotFound();
          }
            var cookingTime = await _context.CookingTime.FindAsync(id);

            if (cookingTime == null)
            {
                return NotFound();
            }

            return cookingTime;
        }

        // PUT: api/CookingTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookingTime(int id, CookingTime cookingTime)
        {
            if (id != cookingTime.Id)
            {
                return BadRequest();
            }

            _context.Entry(cookingTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookingTimeExists(id))
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

        // POST: api/CookingTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookingTime>> PostCookingTime(CookingTime cookingTime)
        {
          if (_context.CookingTime == null)
          {
              return Problem("Entity set 'RecipesContext.CookingTime'  is null.");
          }
            _context.CookingTime.Add(cookingTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookingTime", new { id = cookingTime.Id }, cookingTime);
        }

        // DELETE: api/CookingTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookingTime(int id)
        {
            if (_context.CookingTime == null)
            {
                return NotFound();
            }
            var cookingTime = await _context.CookingTime.FindAsync(id);
            if (cookingTime == null)
            {
                return NotFound();
            }

            _context.CookingTime.Remove(cookingTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CookingTimeExists(int id)
        {
            return (_context.CookingTime?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
