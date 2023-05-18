﻿using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class DishesDetailsHandler : IDishesDetailsHandler
    {
        private readonly IDishesProvider _dishesProvider;
        private readonly IMainMenuHandler _mainMenuHandler;

        public DishesDetailsHandler(IDishesProvider dishesProvider, IMainMenuHandler mainMenuHandler)
        {
            _dishesProvider = dishesProvider;
            _mainMenuHandler = mainMenuHandler;
        }

        public void GetDishesDetails()
        {
            Console.Clear();
            string text = "DISHES DETAILS MAIN MENU\n";
            string text2 = "Please choose your action\n" +
                "1. List of all dishes in database ordered by names\n" +
                "2. List of all dishes in database ordered by calories\n" +
                "3. List of all dishes in database ordered by proteins\n" +
                "4. List of all dishes in database ordered by fat\n" +
                "5. Go back to main menu";


            PrintLinesInCenter(text);
            Console.ReadKey();
            Console.Clear();
            PrintLinesInCenter(text2);
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
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

        private void OrderByCalories()
        {
            Console.WriteLine("\nList of all dishes ordered by calories\n");
            var dishes = _dishesProvider.OrderByCalories();
            foreach (var employee in dishes)
            {
                Console.WriteLine(dishes);
            }
        }
        private void OrderByName()
        {
            Console.WriteLine("\nList of all dishes ordered by name\n");
            var dishes = _dishesProvider.OrderByName();
            foreach (var employee in dishes)
            {
                Console.WriteLine(dishes);
            }
        }
        private void OrderByProteins()
        {
            Console.WriteLine("\nList of all dishes ordered by proteins\n");
            var dishes = _dishesProvider.OrderByProteins();
            foreach (var employee in dishes)
            {
                Console.WriteLine(dishes);
            }
        }
        private void OrderByFat()
        {
            Console.WriteLine("\nList of all dishes ordered by fat\n");
            var dishes = _dishesProvider.OrderByFat();
            foreach (var employee in dishes)
            {
                Console.WriteLine(dishes);
            }
        }
    }
    
}
