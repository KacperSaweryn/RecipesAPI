using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Models;

namespace RecipesAPI.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext (DbContextOptions<RecipesContext> options)
            : base(options)
        {
        }

        public DbSet<RecipesAPI.Models.CookingTime>? CookingTime { get; set; }

        public DbSet<RecipesAPI.Models.Difficulty>? Difficulty { get; set; }

        public DbSet<RecipesAPI.Models.Dish>? Dish { get; set; }

        public DbSet<RecipesAPI.Models.DishType>? DishType { get; set; }

        public DbSet<RecipesAPI.Models.Ingridient>? Ingridient { get; set; }

        public DbSet<RecipesAPI.Models.Tool>? Tool { get; set; }

        public DbSet<RecipesAPI.Models.Unit>? Unit { get; set; }

    }
}
