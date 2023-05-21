using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class Difficulty : DictionaryTable
    {
        public ICollection<Dish>? Dishes { get; set; }
    }
}
