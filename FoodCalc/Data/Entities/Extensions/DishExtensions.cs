using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.Entities
{
    public static class DishExtensions
    {
        public static IEnumerable<Dish> ToDish(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');
                
                yield return new Dish
                {
                    Name = columns[0],
                    Calories = int.Parse(columns[1]),
                    Carbs = int.Parse(columns[2]),
                    Fat = int.Parse(columns[3]),
                    Proteins = int.Parse(columns[4]),
                };
            }
        }
    }
}
