using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;
using RecipesAPI.Models.BusinessLogic;

namespace RecipesAPI.ViewModels
{
    public class DishDifficultyForView : BaseDataTable
    {
        public int? DishId { get; set; }
        public DishForView? DishData { get; set; }
        public int? DifficultyId { get; set; }
        public string? DifficultyName { get; set; }
        public string? DifficultyDescription { get; set; }

        public static explicit operator DishDifficulty(DishDifficultyForView difficultyForView)
        {
            var result = new DishDifficulty().CopyProperties(difficultyForView);
            return result;
        }

        public static implicit operator DishDifficultyForView(DishDifficulty dishDifficulty)
        {
            var result = new DishDifficultyForView().CopyProperties(dishDifficulty);
            if (dishDifficulty.Dish != null)
            {
                result.DishData = DishB.ConvertDishToDishForView(dishDifficulty.Dish);
            }
            if (dishDifficulty.Difficulty != null)
            {
                result.DifficultyName = dishDifficulty.Difficulty.Name;
            }
            if (dishDifficulty.Difficulty != null)
            {
                result.DifficultyDescription = dishDifficulty.Difficulty.Description;
            }
            return result;
        }
    }
}