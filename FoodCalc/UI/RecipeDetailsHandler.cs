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
        private readonly IMainMenuHandler _mainMenuHandler;

        public RecipeDetailsHandler(IRecipeProvider recipeProvider, IMainMenuHandler mainMenuHandler)
        {
            _recipeProvider = recipeProvider;
            _mainMenuHandler = mainMenuHandler;
        }

        public void GetRecipeDetails()
        {
            Console.Clear();
            string text = "RECIPES DETAILS MAIN MENU\n";
            string text2 = "Please choose your action\n" +
                "1. List of all recipes by ingredient\n" +
                "2. List of all recipes by unique ingredients\n" +                
                "3. Go back to main menu";


            PrintLinesInCenter(text);
            Console.ReadKey();
            Console.Clear();
            PrintLinesInCenter(text2);
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    GetRecipesByIngredient();
                    break;
                case "2":
                    GetUniqueIngredients();
                    break;               
                case "3":
                    _mainMenuHandler.SelectMainOption();
                    break;                    
                default:
                    Console.WriteLine("Incorrect command");
                    return;
            }

            Console.ReadKey();

        }
        private static void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;
            foreach (var line in lines)
            {
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
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
