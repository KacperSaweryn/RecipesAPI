using RecipesAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class DishDifficulty : BaseDataTable
    {
        public int? DifficultyId { get; set; }

        [ForeignKey("DifficultyId")]
        public virtual Difficulty? Difficulty { get; set; }
        public int? DishId { get; set; }

        [ForeignKey("DishId")]
        public virtual Dish? Dish { get; set; }
    }
}
