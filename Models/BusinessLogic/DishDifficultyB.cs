using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class DishDifficultyB
    {
        public static async Task ValidateAndFillDishDifficulty(DishDifficultyForView dishDifficulty, RecipesContext _context)
        {
            if (_context.Dish == null)
            {
                throw new Exception("Entity set 'RecipesContext.Dish'  is null.");
            }
            if (_context.Difficulty == null)
            {
                throw new Exception("Entity set 'RecipesContext.Difficulty'  is null.");
            }
            if (dishDifficulty.DishData == null)
            {
                var dish = await _context.Dish.FindAsync(dishDifficulty.DishId);
                if (dish == null)
                {
                    throw new Exception("Dish is null.");
                }
                dishDifficulty.DishData = DishB.ConvertDishToDishForView(dish);
            }

            if (string.IsNullOrEmpty(dishDifficulty.DifficultyName))
            {
                var difficulty = await _context.Difficulty.FindAsync(dishDifficulty.DifficultyId);
                if (difficulty == null)
                {
                    throw new Exception("Difficulty is null.");
                }
                dishDifficulty.DifficultyName = difficulty.Name;
            }

            if (string.IsNullOrEmpty(dishDifficulty.DifficultyDescription))
            {
                var difficulty = await _context.Difficulty.FindAsync(dishDifficulty.DifficultyId);
                if (difficulty == null)
                {
                    throw new Exception("Difficulty is null.");
                }
                dishDifficulty.DifficultyDescription = difficulty.Description;
            }
        }

        public static DishDifficultyForView ConvertDishDifficultyToDishDifficultyForView(DishDifficulty dishDifficulty)
        {
            return new DishDifficultyForView
            {
                DifficultyDescription = dishDifficulty?.Difficulty?.Description ?? String.Empty,
                DifficultyName = dishDifficulty?.Difficulty?.Name ?? String.Empty
            }.CopyProperties(dishDifficulty);
        }
    }
}
