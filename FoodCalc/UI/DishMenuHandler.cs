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
    public class DishMenuHandler : IDishMenuHandler
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IDishesProvider _dishesProvider;
        private readonly IDishesDetailsHandler _dishesDetailsHandler;

        public DishMenuHandler(IRepository<Dish> dishRepository, IDishesProvider dishesProvider, IDishesDetailsHandler dishesDetailsHandler)
        {
            _dishRepository = dishRepository;
            _dishesProvider = dishesProvider;
            _dishesDetailsHandler = dishesDetailsHandler;
        }
        public void SelectYourOption()
        {
            bool inDishMenu = true;
            while (inDishMenu)
            {
                
                string text = "DISHES MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. List of all dishes in database\n" +
                    "2. Add new dish to database\n" +
                    "3. Find dish by id\n" +
                    "4. Show more dish data\n" +
                    "5. Save and go back to main menu";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        WriteAllToConsole(_dishRepository);
                        break;
                    case "2":
                        AddNewDish(_dishRepository);
                        break;
                    case "3":
                        FindDishById(_dishRepository);
                        break;
                    case "4":
                        _dishesDetailsHandler.GetDishesDetails();
                        break;
                    case "5":
                        inDishMenu = CloseAndSave(_dishRepository);
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

        private static void WriteAllToConsole(IRepository<Dish> dishRepository)
        {
            Console.WriteLine("\n--- List of all dishes ---");
            var items = dishRepository.GetAll();
            if (items.ToList().Count == 0)
            {
                Console.WriteLine("No dishes found");
            }
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
        private static void AddNewDish(IRepository<Dish> dishRepository)
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

            var newDish = new Dish
            {
                Name = name,
                Calories = calories,
                Carbs = carbs,
                Fat = fat,
                Proteins = proteins,

            };
            dishRepository.Add(newDish);

        }
        private static Dish? FindDishById(IRepository<Dish> dishRepository)
        {
            while (true)
            {
                Console.WriteLine("Enter the ID of the dish you want to find");
                var selectedId = Console.ReadLine();
                var isParsed = int.TryParse(selectedId, out int selectedValue);
                if (!isParsed)
                {
                    Console.WriteLine("Please enter the number, not a string");
                }
                else
                {
                    var dish = dishRepository.GetByID(selectedValue);
                    if (dish != null)
                    {
                        Console.WriteLine(dish.ToString());
                    }
                    else
                    {
                        Console.WriteLine("There is no dish with given id\n");
                    }
                    return dish;
                }
            }
        }
        private static bool CloseAndSave(IRepository<Dish> dishRepository)
        {
            while (true)
            {

                dishRepository.Save("Dishes");
                    Console.WriteLine("All changes has been saved in file successfully\n");
                    return false;
                
            }
        }
        
    }
    }

