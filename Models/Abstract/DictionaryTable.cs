using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.Abstract
{
    public class DictionaryTable : BaseDataTable
    {
        [Required(ErrorMessage = "This should have a name!")]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}