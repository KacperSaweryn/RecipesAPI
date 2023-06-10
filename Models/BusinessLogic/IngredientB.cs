using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class IngredientB
    {

        public static IngredientForView ConvertIngredientToIngredientForView(Ingredient ing)
        {
            return new IngredientForView
            {
                UnitName = ing?.Unit?.Name ?? String.Empty
            }.CopyProperties(ing);
        }

    }
}
