using FoodCalc.Entities;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionalBuilder)
        {
            // base.OnConfiguring(optionalBuilder);
            // optionalBuilder.UseInMemoryDatabase("SorageAppDb");
            optionalBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IT\PracaDomowa\FoodCalc\FoodCalc\FoodCalcAppDb.mdf;Integrated Security=True");
        }
    }
}
 