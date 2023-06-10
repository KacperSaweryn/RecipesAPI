using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;
using RecipesAPI.Models.BusinessLogic;

namespace RecipesAPI.ViewModels
{
    public class DishIngredientForView : BaseDataTable
    {
        public double Quantity { get; set; }
        public int? DishId { get; set; }
        public DishForView? DishData { get; set; }
        public int? IngredientId { get; set; }
        public string? IngredientName { get; set; }

        public static explicit operator DishIngredient(DishIngredientForView ingridientForView)
        {
            var result = new DishIngredient().CopyProperties(ingridientForView);
            return result;
        }

        public static implicit operator DishIngredientForView(DishIngredient dishIngredient)
        {
            var result = new DishIngredientForView().CopyProperties(dishIngredient);
            if (dishIngredient.Dish != null)
            {
                result.DishData = DishB.ConvertDishToDishForView(dishIngredient.Dish);
            }
            if (dishIngredient.Ingredient != null)
            {
                result.IngredientName = dishIngredient.Ingredient.Name;
            }
            return result;
        }
    }
}