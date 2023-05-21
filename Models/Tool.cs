using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class Tool : DictionaryTable
    {
        public ICollection<Dish>? Dishes { get; set; }
    }
}
