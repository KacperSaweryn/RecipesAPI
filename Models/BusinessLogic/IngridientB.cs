using RecipesAPI.Data;
using RecipesAPI.Helpers;
using RecipesAPI.ViewModels;

namespace RecipesAPI.Models.BusinessLogic
{
    public static class IngridientB
    {
        public static async Task ValidateAndFillIngridient(IngridientForView ingridient, RecipesContext _context)
        {
          
            if (_context.Unit == null)
            {
                throw new Exception("Entity set 'RecipesContext.Unit'  is null.");
            }
          
            if (string.IsNullOrEmpty(ingridient.UnitName))
            {
                var unit = await _context.Unit.FindAsync(ingridient.UnitId);
                if (unit == null)
                {
                    throw new Exception("Unit is null.");
                }
                ingridient.UnitName = unit.Name;
            }
        }

        // public static IngridientForView ConvertIngridientToIngridientForView(Ingridient ingridient)
        // {
        //
        //     return new IngridientForView
        //     {
        //         UnitName = ingridient?.Unit?.Name ?? String.Empty
        //         
        //     }.CopyProperties(ingridient);
        // }
    }
}
