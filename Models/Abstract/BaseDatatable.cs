﻿using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.Abstract
{
    public class BaseDataTable
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
    }
}