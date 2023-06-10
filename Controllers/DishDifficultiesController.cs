using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models;
using RecipesAPI.Models.BusinessLogic;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishDifficultiesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DishDifficultiesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/DishDifficulties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDifficultyForView>>> GetDishDifficulty()
        {
            if (_context.DishDifficulty == null)
            {
                return NotFound();
            }
            return (await _context.DishDifficulty
                .Include(dishDifficulty => dishDifficulty.Dish)
                .Include(dishDifficulty => dishDifficulty.Difficulty)
                .ToListAsync())
                .Select(dishDifficulty => (DishDifficultyForView)dishDifficulty)
                .ToList();
        }

        // GET: api/DishDifficulties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishDifficultyForView>> GetDishDifficulty(int id)
        {
            if (_context.DishDifficulty == null)
            {
                return NotFound();
            }
            
            var dishDifficulty = await _context.DishDifficulty.Include(ing => ing.Difficulty).FirstOrDefaultAsync(diff => diff.Id == id);
            
            if (dishDifficulty == null)
            {
                return NotFound();
            }

            return DishDifficultyB.ConvertDishDifficultyToDishDifficultyForView(dishDifficulty);
        }

        // PUT: api/DishDifficulties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishDifficulty(int id, DishDifficulty dishDifficulty)
        {
            if (id != dishDifficulty.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishDifficulty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishDifficultyExists(id))
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

        // POST: api/DishDifficulties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishDifficultyForView>> PostDishDifficulty(DishDifficultyForView dishDifficulty)
        {
            if (_context.DishDifficulty == null)
            {
                return Problem("Entity set 'RecipesContext.DishDifficulty'  is null.");
            }
            try
            {
                await DishDifficultyB.ValidateAndFillDishDifficulty(dishDifficulty, _context);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            _context.DishDifficulty.Add((DishDifficulty)dishDifficulty);
            await _context.SaveChangesAsync();

            return Ok(dishDifficulty);
        }

        // DELETE: api/DishDifficulties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishDifficulty(int id)
        {
            if (_context.DishDifficulty == null)
            {
                return NotFound();
            }
            var dishDifficulty = await _context.DishDifficulty.FindAsync(id);
            if (dishDifficulty == null)
            {
                return NotFound();
            }

            _context.DishDifficulty.Remove(dishDifficulty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishDifficultyExists(int id)
        {
            return (_context.DishDifficulty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
