using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class Difficulty : DictionaryTable
    {
        public ICollection<DishDifficulty>? DishDifficulties { get; set; }
    }
}
