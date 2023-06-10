using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class Unit : DictionaryTable
    {
        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}