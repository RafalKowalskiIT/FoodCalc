using FoodCalc.Entities;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Ingredients> Ingredients => DbSet<Ingredients>();
    }
}
