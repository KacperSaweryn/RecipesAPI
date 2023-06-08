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
    }
}
