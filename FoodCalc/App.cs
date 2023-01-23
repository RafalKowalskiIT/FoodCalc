using FoodCalc.Components.CsvReader;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;

        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }
        public void Run()
        {
            var dishes = _csvReader.ProcessDish("Resources\\Files\\dishes.csv");
            var ingredients = _csvReader.ProcessIngredients("Resources\\Files\\ingredients.csv");
            var recipes = _csvReader.ProcessRecipes("Resources\\Files\\recipes.csv");

            //var groups = dishes
            //    .GroupBy(x => x.Name)
            //    .Select(g => new
            //    {
            //        Name = g.Key,
            //        Max =g.Max(c=>c.Proteins),
            //        Min =g.Min(c=>c.Fat),

            //    })
            //    .OrderBy(x=>x.Max);

            //foreach (var group in groups)
            //{
            //    Console.WriteLine($"{group.Name}");
            //    Console.WriteLine($"\tProtein:{group.Max}");
            //    Console.WriteLine($"\tFat:{group.Min}");

            //}

            var mealsRec = dishes.Join(
                recipes,
                x => x.Name,
                x => x.Name,
                (dish, recipe) =>
                new
                {
                    dish.Name,
                    recipe.Ingredient1,
                    recipe.Ingredient2,
                    recipe.Ingredient3,

                })
                .OrderByDescending(x => x.Name)
                .ThenBy(x => x.Ingredient1);

            foreach (var recipe in recipes)
            {
                Console.WriteLine($"Name: {recipe.Name}");
                Console.WriteLine($"Ingredients: {recipe.Ingredient1} +\t {recipe.Ingredient2} +\t {recipe.Ingredient3}");
                              
            }
                

                

        }
    }
}
