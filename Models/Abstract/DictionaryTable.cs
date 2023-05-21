﻿using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.Abstract
{
    public class DictionaryTable : BaseDatatable
    {
        [Required(ErrorMessage = "This should have a name!")]
        public string Name { get; set; } = null!;
        
    }
}