using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class RecipeDetailsHandler : IRecipeDetailsHandler
    {
        private readonly IRecipeProvider _recipeProvider;

        public RecipeDetailsHandler(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }

        public void GetRecipeDetails()
        {
            bool inRecipeDetailsMenu = true;
            while (inRecipeDetailsMenu)
            {
                Console.Clear();
                string text = "RECIPES DETAILS MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. List of all recipes by ingredient\n" +
                    "2. List of all recipes by unique ingredients\n" +
                    "3. Go back to main menu";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":                        
                        GetRecipesByIngredient();
                        break;
                    case "2":
                        GetUniqueIngredients();
                        break;
                    case "3":
                        inRecipeDetailsMenu = false;
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

        private void GetRecipesByIngredient()
        {
            Console.WriteLine("\nList of all recipes by ingredients\n");
            var recipes = _recipeProvider.GetUniqueIngredients();
            foreach (var employee in recipes)
            {
                Console.WriteLine(recipes);
            }
        }
        private void GetUniqueIngredients()
        {
            Console.WriteLine("\nList of all recipes by unique ingredients\n");
            var recipes = _recipeProvider.GetUniqueIngredients();
            foreach (var employee in recipes)
            {
                Console.WriteLine(recipes);
            }
        }
       
    }
    
}
