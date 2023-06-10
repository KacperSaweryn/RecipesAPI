using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;
using RecipesAPI.Models.BusinessLogic;

namespace RecipesAPI.ViewModels
{
    public class IngredientForView : DictionaryTable
    {
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }

        public static explicit operator Ingredient(IngredientForView ingridientForView)
        {
            var result = new Ingredient().CopyProperties(ingridientForView);
            return result;
        }

        public static implicit operator IngredientForView(Ingredient ingridient)
        {
            var result = new IngredientForView().CopyProperties(ingridient);
            if (ingridient.Unit != null)
            {
                result.UnitName = ingridient.Unit.Name;
            }
            return result;
        }
    }
}