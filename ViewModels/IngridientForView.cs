using RecipesAPI.Models;
using RecipesAPI.Models.Abstract;
using RecipesAPI.Helpers;

namespace RecipesAPI.ViewModels
{
    public class IngridientForView : DictionaryTable
    {
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
        public string? UnitName { get; set; }
        public static explicit operator Ingridient(IngridientForView ingridientForView)
        {
            var result = new Ingridient().CopyProperties(ingridientForView);
            return result;
        }

        public static implicit operator IngridientForView(Ingridient ingridient)
        {
            var result = new IngridientForView().CopyProperties(ingridient);
            
            if (ingridient.Unit != null)
            {
                result.UnitName = ingridient.Unit.Name;
            }
            return result;
        }
    }
}