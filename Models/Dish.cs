using RecipesAPI.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models
{
    public class Dish : DictionaryTable
    {
        public string Description { get; set; } = null!;

        public int? IngridientId { get; set; }

        [ForeignKey("IngridientId")]
        public virtual Ingridient? Ingridient { get; set; }

        public int? DifficultyId { get; set; }

        [ForeignKey("DifficultyId")]
        public virtual Difficulty? Difficulty { get; set; }

        public int? ToolId { get; set; }

        [ForeignKey("ToolId")]
        public virtual Tool? Tool { get; set; }

        public int? DishTypeId { get; set; }

        [ForeignKey("DishTypeId")]
        public virtual DishType? DishTypeType { get; set; }
    }
}
