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
        public RecipesContext(DbContextOptions<RecipesContext> options)
            : base(options)
        {
        }

        public DbSet<Difficulty>? Difficulty { get; set; }

        public DbSet<Dish>? Dish { get; set; }

        public DbSet<DishType>? DishType { get; set; }

        public DbSet<Ingridient>? Ingridient { get; set; }

        public DbSet<DishIngridient>? DishIngridient { get; set; }

        public DbSet<Tool>? Tool { get; set; }

        public DbSet<Unit>? Unit { get; set; }

    }
}
