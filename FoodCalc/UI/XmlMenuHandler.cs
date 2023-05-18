using FoodCalc.Data.XmlHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.UI
{
    public class XmlMenuHandler : IXmlMenuHandler
    {
        private readonly IXmlHandler _xmlHandler;
        private readonly IMainMenuHandler _mainMenuHandler;

        public XmlMenuHandler(IXmlHandler xmlHandler, IMainMenuHandler mainMenuHandler)
        {
            _xmlHandler = xmlHandler;
            _mainMenuHandler = mainMenuHandler;
        }

        public void SelectYourOption()
        {
            Console.Clear();
            string text = "XML FILES MAIN MENU\n";
            string text2 = "Please choose your action\n" +
                "1. Add dish data to XML file\n" +
                "2. Add ingredients data to XML file\n" +
                "3. Add recipes data to XML file\n" +
                "4. Go back to main menu\n" +
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
                    _xmlHandler.CreateXml("dishes");
                    break;
                case "2":
                    _xmlHandler.CreateXml("ingredients");
                    break;
                case "3":
                    _xmlHandler.CreateXml("recipes");
                    break;
                case "4":
                    _mainMenuHandler.SelectMainOption();
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
