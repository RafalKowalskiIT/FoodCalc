using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.DataProviders
{
    public interface IDishesProvider
    {
        List<Dish> OrderByName();
        List<Dish> OrderByCalories();
        List<Dish> OrderByFat();
        List<Dish> OrderByProteins();
    }
}
