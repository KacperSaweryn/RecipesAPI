using RecipesAPI.Models.Abstract;

namespace RecipesAPI.Models
{
    public class Unit : DictionaryTable
    {

        public ICollection<Ingridient>? Ingridients { get; set; }
        public ICollection<CookingTime>? CookingTimes { get; set; }
    }
}