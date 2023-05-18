using FoodCalc.Components.CsvReader;
using FoodCalc.Data;
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
        private readonly FoodCalcAppDbContext _foodCalcAppDbContext;

        public App(ICsvReader csvReader, FoodCalcAppDbContext foodCalcAppDbContext)
        {
            _csvReader = csvReader;
            _foodCalcAppDbContext = foodCalcAppDbContext;
            _foodCalcAppDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            //InsertData();
            // ReadAllDishes();
            //ReadGroupRecipesFromDb();

            //var dishes = _csvReader.ProcessDish("Resources\\Files\\dishes.csv");
            //var ingredients = _csvReader.ProcessIngredients("Resources\\Files\\ingredients.csv");
            //var recipes = _csvReader.ProcessRecipes("Resources\\Files\\recipes.csv");

            ////var groups = dishes
            ////    .GroupBy(x => x.Name)
            ////    .Select(g => new
            ////    {
            ////        Name = g.Key,
            ////        Max =g.Max(c=>c.Proteins),
            ////        Min =g.Min(c=>c.Fat),

            ////    })
            ////    .OrderBy(x=>x.Max);

            ////foreach (var group in groups)
            ////{
            ////    Console.WriteLine($"{group.Name}");
            ////    Console.WriteLine($"\tProtein:{group.Max}");
            ////    Console.WriteLine($"\tFat:{group.Min}");

            ////}

            //var mealsRec = dishes.Join(
            //    recipes,
            //    x => x.Name,
            //    x => x.Name,
            //    (dish, recipe) =>
            //    new
            //    {
            //        dish.Name,
            //        recipe.Ingredient1,
            //        recipe.Ingredient2,
            //        recipe.Ingredient3,
            //        recipe.Ingredient4,
            //        recipe.Ingredient5,

            //    })
            //    .ToList();

            //    var result = mealsRec.Join(
            //        ingredients,
            //        m => new { m.Ingredient1, m.Ingredient2, m.Ingredient3, m.Ingredient4, m.Ingredient5 },
            //        i => new { i.Name },
            //        (mealsRec, ingredients) =>
            //        new
            //        {
            //            mealsRec.Name,
            //            ingredients.Calories,
            //            ingredients.Fat,
            //            ingredients.Carbs,
            //            ingredients.Proteins,
            //        })
            //    .OrderByDescending(x => x.Name)
            //    .ThenBy(x => x.Calories);

            //foreach (var recipe in recipes)
            //{
            //    Console.WriteLine($"Name: {recipe.Name}");
            //    Console.WriteLine($"Ingredients: \t{recipe.Ingredient1} + {recipe.Ingredient2} + {recipe.Ingredient3}+ {recipe.Ingredient4}+ {recipe.Ingredient5}");

            //}

        }

        private void ReadGroupRecipesFromDb()
        {
            var groups = _foodCalcAppDbContext
                .Recipes
                .GroupBy(x => x.Name)
                .Select(x => new
                {
                    Name = x.Key,
                    Recipe = x.ToList()
                })
                .ToList();

            foreach (var group in groups)
            {
                Console.WriteLine(group.Name);
                Console.WriteLine("======");
                foreach (var recipe in group.Recipe)
                {
                    Console.WriteLine($"\t {recipe.Ingredient1}\n\t {recipe.Ingredient2}\n\t {recipe.Ingredient3}\n\t {recipe.Ingredient4}\n\t {recipe.Ingredient5}");
                }
                Console.WriteLine();
            }
        }



        private void ReadAllDishes()
        {
            var dishesFromDb = _foodCalcAppDbContext.Dishes.ToList();

            foreach (var dishFromDb in dishesFromDb)
            {
                Console.WriteLine($"\t {dishFromDb.Name}: {dishFromDb.Calories}");
            }
        }

        private void InsertData()
        {
            var dishes = _csvReader.ProcessDish("Resources\\Files\\dishes.csv");
            var ingredients = _csvReader.ProcessIngredients("Resources\\Files\\ingredients.csv");
            var recipes = _csvReader.ProcessRecipes("Resources\\Files\\recipes.csv");

            foreach (var dish in dishes)
            {
                _foodCalcAppDbContext.Dishes.Add(new Dish()
                {
                    Name = dish.Name,
                    Calories = dish.Calories,
                    Carbs = dish.Carbs,
                    Fat = dish.Fat,
                    Proteins = dish.Proteins,
                });

            }

            foreach (var ingredient in ingredients)
            {
                _foodCalcAppDbContext.Ingredients.Add(new Ingredients()
                {
                    Name = ingredient.Name,
                    Calories = ingredient.Calories,
                    Carbs = ingredient.Carbs,
                    Fat = ingredient.Fat,
                    Proteins = ingredient.Proteins,
                });
            }

            foreach (var recipe in recipes)
            {
                _foodCalcAppDbContext.Recipes.Add(new Recipe()
                {
                    Name = recipe.Name,
                    Ingredient1 = recipe.Ingredient1,
                    Ingredient2 = recipe.Ingredient2,
                    Ingredient3 = recipe.Ingredient3,
                    Ingredient4 = recipe.Ingredient4,
                    Ingredient5 = recipe.Ingredient5,

                });
            }

            _foodCalcAppDbContext.SaveChanges();
        }
    }
}
