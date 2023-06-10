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
    public class DishIngredientsController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DishIngredientsController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/DishIngredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishIngredientForView>>> GetDishIngredient()
        {
            if (_context.DishIngredient == null)
            {
                return NotFound();
            }
            return (await _context.DishIngredient
                .Include(dishIngredient => dishIngredient.Dish)
                .Include(dishIngredient => dishIngredient.Ingredient)
                .ToListAsync())
                .Select(dishIngredient => (DishIngredientForView)dishIngredient)
                .ToList();
        }

        // GET: api/DishIngredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishIngredientForView>> GetDishIngredient(int id)
        {
            if (_context.DishIngredient == null)
            {
                return NotFound();
            }
            var dishIngredient = await _context.DishIngredient.FindAsync(id);

            if (dishIngredient == null)
            {
                return NotFound();
            }

            return Ok(dishIngredient);
        }

        // PUT: api/DishIngredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishIngredient(int id, DishIngredient dishIngredient)
        {
            if (id != dishIngredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishIngredientExists(id))
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

        // POST: api/DishIngredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishIngredientForView>> PostDishIngredient(DishIngredientForView dishIngredient)
        {
            if (_context.DishIngredient == null)
            {
                return Problem("Entity set 'GrzechuWarteContext.DishIngredient'  is null.");
            }
            try
            {
                await DishIngredientB.ValidateAndFillDishIngredient(dishIngredient, _context);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            _context.DishIngredient.Add((DishIngredient)dishIngredient);
            await _context.SaveChangesAsync();

            return Ok(dishIngredient);
        }

        // DELETE: api/DishIngredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishIngredient(int id)
        {
            if (_context.DishIngredient == null)
            {
                return NotFound();
            }
            var dishIngredient = await _context.DishIngredient.FindAsync(id);
            if (dishIngredient == null)
            {
                return NotFound();
            }

            _context.DishIngredient.Remove(dishIngredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishIngredientExists(int id)
        {
            return (_context.DishIngredient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
