using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class DishB
    {

        public static DishForView ConvertDishToDishForView(Dish dish)
        {
            return new DishForView
            {
                DishTypeName = dish?.DishType?.Name ?? String.Empty
            }.CopyProperties(dish);
        }

        public async static Task<bool> DeleteDishIngredients(Dish dish, RecipesContext _context)
        {
            var dishIngredients = _context.DishIngredient.Where(ingridient => ingridient.DishId == dish.Id).ToList();
            foreach (var ingridient in dishIngredients)
            {
                _context.Remove(ingridient);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async static Task<bool> DeleteDishDifficulties(Dish dish, RecipesContext _context)
        {
            var dishDifficultiess = _context.DishDifficulty.Where(difficulty => difficulty.DishId == dish.Id).ToList();
            foreach (var difficulty in dishDifficultiess)
            {
                _context.Remove(difficulty);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
