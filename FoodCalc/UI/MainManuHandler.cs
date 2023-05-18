using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class MainMenuHandler : IMainMenuHandler
    {
        private readonly IDishMenuHandler _dishMenuHandler;
        private readonly IIngredientsMenuHandler _ingredientsMenuHandler;
        private readonly IRecipeMenuHandler _recipeMenuHandler;
        private readonly IXmlMenuHandler _xmlMenuHandler;

        public MainMenuHandler(IDishMenuHandler dishMenuHandler, IIngredientsMenuHandler ingredientsMenuHandler, IRecipeMenuHandler recipeMenuHandler, IXmlMenuHandler xmlMenuHandler)
        {
            _dishMenuHandler = dishMenuHandler;
            _ingredientsMenuHandler = ingredientsMenuHandler;
            _recipeMenuHandler = recipeMenuHandler;
            _xmlMenuHandler = xmlMenuHandler;
        }



        public void SelectMainOption()
        {
            Console.Clear();
            string text = "MAIN MENU\n";
            string text2 = "Please choose your action\n" +
                "1. Dishes database\n" +
                "2. Ingredients database\n" +
                "3. Recipes database\n" +
                "4. XML files\n" +
                "5. Exit";
            

            PrintLinesInCenter(text);
            Console.ReadKey();
            Console.Clear();
            PrintLinesInCenter(text2);
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    _dishMenuHandler.SelectYourOption();
                    break;
                case "2":
                    _ingredientsMenuHandler.SelectYourOption();
                    break;
                case "3":
                    _recipeMenuHandler.SelectYourOption();
                    break;
                case "4":
                    _xmlMenuHandler.SelectYourOption();
                    break;
                case "5":
                    Console.Clear();
                    PrintLinesInCenter("BYE");
                    break;
                default:
                    Console.WriteLine("Incorrect command");
                    return;
            }

            Console.ReadKey();



            static void PrintLinesInCenter(params string[] lines)
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
        }
    }
}



