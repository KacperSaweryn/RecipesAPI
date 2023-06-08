using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;
using RecipesAPI.Models.BusinessLogic;

namespace RecipesAPI.ViewModels
{
    public class DishIngridientForView : BaseDataTable
    {
        public double Quantity { get; set; }
        public int? DishId { get; set; }
        public DishForView? DishData { get; set; }
        public int? IngridientId { get; set; }
        public string? IngridientName { get; set; }

        public static explicit operator DishIngridient(DishIngridientForView ingridientForView)
        {
            var result = new DishIngridient().CopyProperties(ingridientForView);
            return result;
        }

        public static implicit operator DishIngridientForView(DishIngridient dishIngridient)
        {
            var result = new DishIngridientForView().CopyProperties(dishIngridient);
            if (dishIngridient.Dish != null)
            {
                result.DishData = DishB.ConvertDishToDishForView(dishIngridient.Dish);
            }
            if (dishIngridient.Ingridient != null)
            {
                result.IngridientName = dishIngridient.Ingridient.Name;
            }
            return result;
        }
    }
}