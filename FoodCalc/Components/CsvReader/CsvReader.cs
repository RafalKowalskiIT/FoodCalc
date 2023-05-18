using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Components.CsvReader
{
    public class CsvReader : ICsvReader
    {
        public List<Dish> ProcessDish(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Dish>();
            }

            var dishes = File.ReadAllLines(filePath)
                .Where(l => l.Length > 1)
                .ToDish();

            return dishes.ToList();
        }

        public List<Ingredients> ProcessIngredients(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<Ingredients>();
            }

            var ingredients = File.ReadAllLines(filePath)
                .Skip(1)
                .Where(l => l.Length > 1)
                .Select(x =>
                {
                    var columns = x.Split(',');
                    return new Ingredients()
                    {
                        Name = columns[0],
                        Calories = double.Parse(columns[1]),
                        Carbs = double.Parse(columns[2]),
                        Fat = double.Parse(columns[3]),
                        Proteins = double.Parse(columns[4])
                    };

                });
            return ingredients.ToList();
        }

        public List<Recipe> ProcessRecipes(string filePath)
        {
            if(!File.Exists(filePath))
            {
                return new List<Recipe>();
            }

            var recipe = File.ReadAllLines(filePath)
                .Where(l => l.Length > 1)
                .Select(x =>
                {
                    var columns = x.Split(',');
                    return new Recipe()
                    {
                        Name = columns[0],
                        Ingredient1 = columns[1],
                        Ingredient2 = columns[2],
                        Ingredient3 = columns[3],
                        Ingredient4 = columns[4],
                        Ingredient5 = columns[5],                  

                    };
                });
            return recipe.ToList();
        }

    }
}
