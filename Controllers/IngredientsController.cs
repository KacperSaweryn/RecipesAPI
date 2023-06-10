using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class IngredientsController : ControllerBase
    {
        private readonly RecipesContext _context;

        public IngredientsController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientForView>>> GetIngredient()
        {
            if (_context.Ingredient == null)
            {
                return NotFound();
            }
            return (await _context.Ingredient
                        .Include(ingridient => ingridient.Unit)
                        .ToListAsync())
                        .Select(type => (IngredientForView)type)
                        .ToList();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientForView>> GetIngredient(int id)
        {
            if (_context.Ingredient == null)
            {
                return NotFound();
            }

            var ingridient = await _context.Ingredient.Include(ing => ing.Unit).FirstOrDefaultAsync(ing => ing.Id == id);

            if (ingridient == null)
            {
                return NotFound();
            }

            return IngredientB.ConvertIngredientToIngredientForView(ingridient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, IngredientForView ingridient)
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
                if (!IngredientExists(id))
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

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientForView>> PostIngredient(IngredientForView ingridient)
        {
            if (_context.Ingredient == null)
            {
                return Problem("Entity set 'RecipesContext.Ingredient'  is null.");
            }
            _context.Ingredient.Add((Ingredient)ingridient);
            await _context.SaveChangesAsync();

            return Ok(ingridient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            if (_context.Ingredient == null)
            {
                return NotFound();
            }
            var ingridient = await _context.Ingredient.FindAsync(id);
            if (ingridient == null)
            {
                return NotFound();
            }

            _context.Ingredient.Remove(ingridient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            return (_context.Ingredient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
