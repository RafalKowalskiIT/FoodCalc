
using FoodCalc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data
{
    public class FoodCalcAppDbContext : DbContext
    {
        public DbSet<Dish> Dishes => Set<Dish>();
        public DbSet<Ingredients> Ingredients => Set<Ingredients>();
        public DbSet<Recipe> Recipes => Set<Recipe>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionalBuilder)
        {           
            optionalBuilder.UseSqlServer(@"Data Source=RAFAL-KOMPUTER\SQLEXPRESS;Initial Catalog=FoodCalcDb;Encrypt=False;Integrated Security=True");
        }
    }
}
 