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

        public XmlMenuHandler(IXmlHandler xmlHandler)
        {
            _xmlHandler = xmlHandler;
        }

        public void SelectYourOption()
        {
            bool inXmlMenu = true;
            while (inXmlMenu)
            {
                Console.Clear();
                string text = "XML FILES MAIN MENU\n";
                string text2 = "Please choose your action\n" +
                    "1. Add dish data to XML file\n" +
                    "2. Add ingredients data to XML file\n" +
                    "3. Add recipes data to XML file\n" +
                    "4. Go back to main menu\n" +
                    "5. Exit";


                Console.WriteLine(text);
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine(text2);
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":                        
                        _xmlHandler.CreateXml("Dishes");
                        break;
                    case "2":
                        _xmlHandler.CreateXml("Ingredients");
                        break;
                    case "3":
                        _xmlHandler.CreateXml("Recipes");
                        break;
                    case "4":
                        inXmlMenu = false;
                        break;
                    case "5":                        
                        PrintLinesInCenter("BYE");
                        inXmlMenu = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect command");
                        continue;
                }
            }
            Console.ReadKey();



            static void PrintLinesInCenter(params string[] lines)
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
        }
    }
}
