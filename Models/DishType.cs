using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class DishType : DictionaryTable
    {
        public ICollection<Dish>? Dishes { get; set; }
    }
}
