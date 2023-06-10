using RecipesAPI.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class Dish : DictionaryTable
    {

        public int? DishTypeId { get; set; }

        [ForeignKey("DishTypeId")]
        public virtual DishType? DishType { get; set; }

        public ICollection<DishIngredient>? DishIngredients { get; set; }

        public ICollection<Difficulty>? Difficulties { get; set; }

        public ICollection<Tool>? Tools { get; set; }
    }
}
