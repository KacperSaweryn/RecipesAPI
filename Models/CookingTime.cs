using RecipesAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class CookingTime : DictionaryTable
    {
        [ForeignKey("UnitId")]
        public virtual Unit? Unit { get; set; }
        public ICollection<Dish>? Dishes { get; set; }
    }
}
