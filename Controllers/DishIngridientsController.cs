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
    public class DishIngridientsController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DishIngridientsController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/DishIngridients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishIngridientForView>>> GetDishIngridient()
        {
          if (_context.DishIngridient == null)
          {
              return NotFound();
          }
            return (await _context.DishIngridient
                .Include(dishIngridient => dishIngridient.Dish)
                .Include(dishIngridient => dishIngridient.Ingridient)
                .ToListAsync())
                .Select(dishIngridient => (DishIngridientForView)dishIngridient)
                .ToList();
        }

        // GET: api/DishIngridients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishIngridientForView>> GetDishIngridient(int id)
        {
          if (_context.DishIngridient == null)
          {
              return NotFound();
          }
            var dishIngridient = await _context.DishIngridient.FindAsync(id);

            if (dishIngridient == null)
            {
                return NotFound();
            }

            return Ok(dishIngridient);
        }

        // PUT: api/DishIngridients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishIngridient(int id, DishIngridient dishIngridient)
        {
            if (id != dishIngridient.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishIngridient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishIngridientExists(id))
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

        // POST: api/DishIngridients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishIngridientForView>> PostDishIngridient(DishIngridientForView dishIngridient)
        {
            if (_context.DishIngridient == null)
            {
                return Problem("Entity set 'GrzechuWarteContext.DishIngridient'  is null.");
            }
            try
            {
                await DishIngridientB.ValidateAndFillDishIngridient(dishIngridient, _context);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }

            _context.DishIngridient.Add((DishIngridient)dishIngridient);
            await _context.SaveChangesAsync();

            return Ok(dishIngridient);
        }

        // DELETE: api/DishIngridients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishIngridient(int id)
        {
            if (_context.DishIngridient == null)
            {
                return NotFound();
            }
            var dishIngridient = await _context.DishIngridient.FindAsync(id);
            if (dishIngridient == null)
            {
                return NotFound();
            }

            _context.DishIngridient.Remove(dishIngridient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishIngridientExists(int id)
        {
            return (_context.DishIngridient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
