using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class IngredientsDetailsHandler : IIngredientsDetailsHandler
    {
        private readonly IIngredientsProvider _ingredientsProvider;

        public IngredientsDetailsHandler(IIngredientsProvider ingredientsProvider)
        {
            _ingredientsProvider = ingredientsProvider;
        }

        public void GetIngredientsDetails()
        {
            bool inIngredientsDetailsMenu = true;
            while (inIngredientsDetailsMenu)
            {
                Console.Clear();
                string text = "INGREDIENTS DETAILS MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. List of all ingredients in database ordered by names\n" +
                    "2. List of all ingredients in database ordered by calories\n" +
                    "3. List of all ingredients in database ordered by proteins\n" +
                    "4. List of all ingredients in database ordered by fat\n" +
                    "5. Go back to main menu";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        OrderByName();
                        break;
                    case "2":
                        OrderByCalories();
                        break;
                    case "3":
                        OrderByProteins();
                        break;
                    case "4":
                        OrderByFat();
                        break;
                    case "5":
                        inIngredientsDetailsMenu = false;
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

        private void OrderByCalories()
        {
            Console.WriteLine("\nList of all ingredients ordered by calories\n");
            var ingredients = _ingredientsProvider.OrderByCalories();
            foreach (var employee in ingredients)
            {
                Console.WriteLine(ingredients);
            }
        }
        private void OrderByName()
        {
            Console.WriteLine("\nList of all ingredients ordered by name\n");
            var ingredients = _ingredientsProvider.OrderByName();
            foreach (var employee in ingredients)
            {
                Console.WriteLine(ingredients);
            }
        }
        private void OrderByProteins()
        {
            Console.WriteLine("\nList of all ingredients ordered by proteins\n");
            var ingredients = _ingredientsProvider.OrderByProteins();
            foreach (var employee in ingredients)
            {
                Console.WriteLine(ingredients);
            }
        }
        private void OrderByFat()
        {
            Console.WriteLine("\nList of all dishes ordered by fat\n");
            var ingredients = _ingredientsProvider.OrderByFat();
            foreach (var employee in ingredients)
            {
                Console.WriteLine(ingredients);
            }
        }
    }
    
}
