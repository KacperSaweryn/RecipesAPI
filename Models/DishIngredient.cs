using RecipesAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class DishIngredient : BaseDataTable
    {
        public double Quantity { get; set; }
        public int? IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public virtual Ingredient? Ingredient { get; set; }
        public int? DishId { get; set; }

        [ForeignKey("DishId")]
        public virtual Dish? Dish { get; set; }
    }
}
