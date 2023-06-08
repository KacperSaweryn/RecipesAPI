using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;
using RecipesAPI.Models.BusinessLogic;

namespace RecipesAPI.ViewModels
{
    public class DishForView : DictionaryTable
    {

        public int? DishTypeId { get; set; }
        public string? DishTypeName { get; set; }

        public static explicit operator Dish(DishForView dishForView)
        {
            var result = new Dish().CopyProperties(dishForView);
            return result;
        }

        public static implicit operator DishForView(Dish dish)
        {
            var result = new DishForView().CopyProperties(dish);

            if (dish.DishType != null)
            {
                result.DishTypeName = dish.DishType.Name;
            }
            return result;
        }
    }
}