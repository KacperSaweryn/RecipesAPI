using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class DishIngridientB
    {
        public static async Task ValidateAndFillDishIngridient(DishIngridientForView dishIngridient, RecipesContext _context)
        {
            if (_context.Dish == null)
            {
                throw new Exception("Entity set 'GrzechuWarteContext.Dish'  is null.");
            }
            if (_context.Ingridient == null)
            {
                throw new Exception("Entity set 'GrzechuWarteContext.Ingridient'  is null.");
            }
            if (dishIngridient.DishData == null)
            {
                var dish = await _context.Dish.FindAsync(dishIngridient.DishId);
                if (dish == null)
                {
                    throw new Exception("Dish is null.");
                }
                dishIngridient.DishData = DishB.ConvertDishToDishForView(dish);
            }
            if (string.IsNullOrEmpty(dishIngridient.IngridientName))
            {
                var ingridient = await _context.Ingridient.FindAsync(dishIngridient.DishId);
                if (ingridient == null)
                {
                    throw new Exception("Ingridient is null.");
                }
                dishIngridient.IngridientName = ingridient.Name;
            }
        }
    }
}
