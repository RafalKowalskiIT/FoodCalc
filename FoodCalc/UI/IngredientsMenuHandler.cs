
using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class IngredientsMenuHandler : IIngredientsMenuHandler
    {
        private readonly IRepository<Ingredients> _ingredientsRepository;
        private readonly IIngredientsProvider _ingredientsProvider;
        private readonly IIngredientsDetailsHandler _ingredientsDetailsHandler;

        public IngredientsMenuHandler(IRepository<Ingredients> ingredientsRepository, IIngredientsProvider ingredientsProvider, IIngredientsDetailsHandler ingredientsDetailsHandler)
        {
            _ingredientsRepository = ingredientsRepository;
            _ingredientsProvider = ingredientsProvider;
            _ingredientsDetailsHandler = ingredientsDetailsHandler;
        }
        public void SelectYourOption()
        {
            bool inIngrediensMenu = true;
            while (inIngrediensMenu)
            {
                Console.Clear();
                string text = "INGREDIENTS MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. List of all ingredients in database\n" +
                    "2. Add new ingredients to database\n" +
                    "3. Find ingredient by id\n" +
                    "4. Show more ingredients data\n" +
                    "5. Save and go back to main menu";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        WriteAllToConsole(_ingredientsRepository);
                        break;
                    case "2":
                        AddNewIngredients(_ingredientsRepository);
                        break;
                    case "3":
                        FindIngredientsById(_ingredientsRepository);
                        break;
                    case "4":
                        _ingredientsDetailsHandler.GetIngredientsDetails();
                        break;
                    case "5":
                        CloseAndSave(_ingredientsRepository);
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

        private static void WriteAllToConsole(IRepository<Ingredients> ingredientsRepository)
        {
            Console.WriteLine("\n--- List of all ingredients ---");
            var items = ingredientsRepository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No ingredient found");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        private static void AddNewIngredients(IRepository<Ingredients> ingredientsRepository)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Calories: ");
            var calories = int.Parse(Console.ReadLine());
            Console.WriteLine("Carbs: ");
            var carbs = int.Parse(Console.ReadLine());
            Console.WriteLine("Fat: ");
            var fat = int.Parse(Console.ReadLine());
            Console.WriteLine("Proteins: ");
            var proteins = int.Parse(Console.ReadLine());

            var newIngredients = new Ingredients
            {
                Name = name,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Proteins = proteins,

            };
            ingredientsRepository.Add(newIngredients);

        }
        private static Ingredients? FindIngredientsById(IRepository<Ingredients> ingredientsRepository)
        {
            while (true)
            {
                Console.WriteLine("Enter the ID of the ingredient you want to find");
                var selectedId = Console.ReadLine();
                var isParsed = int.TryParse(selectedId, out int selectedValue);
                if (!isParsed)
                {
                    Console.WriteLine("Please enter the number, not a string");
                }
                else
                {
                    var ingredient = ingredientsRepository.GetByID(selectedValue);
                    if (ingredient != null)
                    {
                        Console.WriteLine(ingredient.ToString());
                    }
                    else
                    {
                        Console.WriteLine("There is no ingredient with given id\n");
                    }
                    return ingredient;
                }
            }
        }
        private static bool CloseAndSave(IRepository<Ingredients> ingredientRepository)
        {
            while (true)
            {

                ingredientRepository.Save("Ingredients");
                    Console.WriteLine("All changes has been saved in file successfully\n");
                    return false;

            }
        }
        
    }
    }

