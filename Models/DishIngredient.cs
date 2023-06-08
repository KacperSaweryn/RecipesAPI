using RecipesAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class DishIngridient : BaseDataTable
    {
        public double Quantity { get; set; }
        public int? IngridientId { get; set; }

        [ForeignKey("IngridientId")]
        public virtual Ingridient? Ingridient { get; set; }
        public int? DishId { get; set; }

        [ForeignKey("DishId")]
        public virtual Dish? Dish { get; set; }
    }
}
