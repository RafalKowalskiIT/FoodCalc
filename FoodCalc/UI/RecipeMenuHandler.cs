
using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    internal class RecipeMenuHandler : IRecipeMenuHandler
    {
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly IRecipeProvider _recipeProvider;
        private readonly IRecipeDetailsHandler _recipeDetailsHandler;

        public RecipeMenuHandler(IRepository<Recipe> recipeRepository, IRecipeProvider recipeProvider, IRecipeDetailsHandler recipeDetailsHandler)
        {
            _recipeRepository = recipeRepository;
            _recipeProvider = recipeProvider;
            _recipeDetailsHandler = recipeDetailsHandler;
        }
        public void SelectYourOption()
        {
            bool inRecipeMenu = true;
            while (inRecipeMenu)
            {
                Console.Clear();
                string text = "RECIPES MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. List of all recipes in database\n" +
                    "2. Add new recipes to database\n" +
                    "3. Find recipe by id\n" +
                    "4. Show more recipes data\n" +
                    "5. Save and go back to main menu";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":                        
                        WriteAllToConsole(_recipeRepository);
                        break;
                    case "2":
                        AddNewRecipe(_recipeRepository);
                        break;
                    case "3":
                        FindRecipeById(_recipeRepository);
                        break;
                    case "4":
                        _recipeDetailsHandler.GetRecipeDetails();
                        break;
                    case "5":                        
                        CloseAndSave(_recipeRepository);
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }
            }
            Console.ReadKey();

        }
        private static void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight) / 2;
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                int horizontalStart = (Console.WindowWidth) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }
        }

        private static void WriteAllToConsole(IRepository<Recipe> recipeRepository)
        {
            Console.WriteLine("\n--- List of all recipes ---");
            var items = recipeRepository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No recipe found");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        private static void AddNewRecipe(IRepository<Recipe> recipeRepository)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Ingredient: ");
            var Ingredient1 = Console.ReadLine();
            Console.WriteLine("Ingredient: ");
            var Ingredient2 = Console.ReadLine();
            Console.WriteLine("Ingredient: ");
            var Ingredient3 = Console.ReadLine();
            Console.WriteLine("Ingredient: ");
            var Ingredient4 = Console.ReadLine();
            Console.WriteLine("Ingredient: ");
            var Ingredient5 = Console.ReadLine();

            var newRecipe = new Recipe
            {
                Name = name,
                Ingredient1 = Ingredient1,
                Ingredient2 = Ingredient2,
                Ingredient3 = Ingredient3,
                Ingredient4 = Ingredient4,
                Ingredient5 = Ingredient5,
            };
            recipeRepository.Add(newRecipe);

        }
        private static Recipe? FindRecipeById(IRepository<Recipe> recipeRepository)
        {
            while (true)
            {
                Console.WriteLine("Enter the ID of the recipe you want to find");
                var selectedId = Console.ReadLine();
                var isParsed = int.TryParse(selectedId, out int selectedValue);
                if (!isParsed)
                {
                    Console.WriteLine("Please enter the number, not a string");
                }
                else
                {
                    var recipe = recipeRepository.GetByID(selectedValue);
                    if (recipe != null)
                    {
                        Console.WriteLine(recipe.ToString());
                    }
                    else
                    {
                        Console.WriteLine("There is no recipe with given id\n");
                    }
                    return recipe;
                }
            }
        }
        private static bool CloseAndSave(IRepository<Recipe> recipeRepository)
        {
            while (true)
            {

                recipeRepository.Save("Recipes");
                Console.WriteLine("All changes has been saved in file successfully\n");
                return false;

            }
        }

    }
}

