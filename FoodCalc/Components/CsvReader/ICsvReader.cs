
using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Dish> ProcessDish(string filePath);

        List<Ingredients> ProcessIngredients(string filePath);

        List<Recipe> ProcessRecipes(string filePath);
    }
}
