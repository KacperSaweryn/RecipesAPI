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
    public class DifficultiesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DifficultiesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/Difficulties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Difficulty>>> GetDifficulty()
        {
          if (_context.Difficulty == null)
          {
              return NotFound();
          }
            return await _context.Difficulty.ToListAsync();
        }

        // GET: api/Difficulties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Difficulty>> GetDifficulty(int id)
        {
          if (_context.Difficulty == null)
          {
              return NotFound();
          }
            var difficulty = await _context.Difficulty.FindAsync(id);

            if (difficulty == null)
            {
                return NotFound();
            }

            return difficulty;
        }

        // PUT: api/Difficulties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifficulty(int id, Difficulty difficulty)
        {
            if (id != difficulty.Id)
            {
                return BadRequest();
            }

            _context.Entry(difficulty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifficultyExists(id))
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

        // POST: api/Difficulties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Difficulty>> PostDifficulty(Difficulty difficulty)
        {
          if (_context.Difficulty == null)
          {
              return Problem("Entity set 'RecipesContext.Difficulty'  is null.");
          }
            _context.Difficulty.Add(difficulty);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Difficulties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficulty(int id)
        {
            if (_context.Difficulty == null)
            {
                return NotFound();
            }
            var difficulty = await _context.Difficulty.FindAsync(id);
            if (difficulty == null)
            {
                return NotFound();
            }

            _context.Difficulty.Remove(difficulty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DifficultyExists(int id)
        {
            return (_context.Difficulty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
