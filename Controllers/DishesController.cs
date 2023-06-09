using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.Models;
using RecipesAPI.Models.BusinessLogic;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DishesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishForView>>> GetDish()
        {
          if (_context.Dish == null)
          {
              return NotFound();
          }
            return (await _context
                .Dish
                .Include(dish => dish.DishType)
                .ToListAsync())
                .Select(dish => DishB.ConvertDishToDishForView(dish))
                .ToList();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishForView>> GetDish(int id)
        {
          if (_context.Dish == null)
          {
              return NotFound();
          }
            var dish = await _context.Dish.FindAsync(id);
            
            if (dish == null)
            {
                return NotFound();
            }

            return DishB.ConvertDishToDishForView(dish);
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(int id, DishForView dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishForView>> PostDish(DishForView dish)
        {
          if (_context.Dish == null)
          {
              return Problem("Entity set 'RecipesContext.Dish'  is null.");
          }
          var dishToAdd = new Dish().CopyProperties(dish);
            _context.Dish.Add(dishToAdd);
            await _context.SaveChangesAsync();

            return Ok(dish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int id)
        {
            if (_context.Dish == null)
            {
                return NotFound();
            }
            var dish = await _context.Dish.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dish.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishExists(int id)
        {
            return (_context.Dish?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
