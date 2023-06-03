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
    public class DishTypesController : ControllerBase
    {
        private readonly RecipesContext _context;

        public DishTypesController(RecipesContext context)
        {
            _context = context;
        }

        // GET: api/DishTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishType>>> GetDishType()
        {
          if (_context.DishType == null)
          {
              return NotFound();
          }
            return await _context.DishType.ToListAsync();
        }

        // GET: api/DishTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishType>> GetDishType(int id)
        {
          if (_context.DishType == null)
          {
              return NotFound();
          }
            var dishType = await _context.DishType.FindAsync(id);

            if (dishType == null)
            {
                return NotFound();
            }

            return dishType;
        }

        // PUT: api/DishTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishType(int id, DishType dishType)
        {
            if (id != dishType.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishTypeExists(id))
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

        // POST: api/DishTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishType>> PostDishType(DishType dishType)
        {
          if (_context.DishType == null)
          {
              return Problem("Entity set 'RecipesContext.DishType'  is null.");
          }
            _context.DishType.Add(dishType);
            await _context.SaveChangesAsync();

            return Ok(dishType);
        }

        // DELETE: api/DishTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishType(int id)
        {
            if (_context.DishType == null)
            {
                return NotFound();
            }
            var dishType = await _context.DishType.FindAsync(id);
            if (dishType == null)
            {
                return NotFound();
            }

            _context.DishType.Remove(dishType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishTypeExists(int id)
        {
            return (_context.DishType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
