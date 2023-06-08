using RecipesAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class Ingridient : DictionaryTable
    {
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit? Unit { get; set; }

        public ICollection<DishIngridient>? DishIngridients { get; set; }
    }
}
