using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class DishIngredientB
    {
        public static async Task ValidateAndFillDishIngredient(DishIngredientForView dishIngredient, RecipesContext _context)
        {
            if (_context.Dish == null)
            {
                throw new Exception("Entity set 'RecipesContext.Dish'  is null.");
            }
            if (_context.Ingredient == null)
            {
                throw new Exception("Entity set 'RecipesContext.Ingredient'  is null.");
            }
            if (dishIngredient.DishData == null)
            {
                var dish = await _context.Dish.FindAsync(dishIngredient.DishId);
                if (dish == null)
                {
                    throw new Exception("Dish is null.");
                }
                dishIngredient.DishData = DishB.ConvertDishToDishForView(dish);
            }

            if (string.IsNullOrEmpty(dishIngredient.IngredientName))
            {
                var ingridient = await _context.Ingredient.FindAsync(dishIngredient.IngredientId);
                if (ingridient == null)
                {
                    throw new Exception("Ingredient is null.");
                }
                dishIngredient.IngredientName = ingridient.Name;
            }
        }
    }
}
