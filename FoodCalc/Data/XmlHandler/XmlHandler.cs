
using System.Xml.Linq;

using FoodCalc.Components.CsvReader;
using FoodCalc.Components.CsvReader.Models;

namespace FoodCalc.Data.XmlHandler
{
    public class XmlHandler : IXmlHandler
    {
        private readonly ICsvReader _csvReader;
        public XmlHandler() 
        { 
            _csvReader = new CsvReader();
        }
        public void CreateXml(string description)
        {
            if (description == "Dishes")
            {
                var records = _csvReader.ProcessDish(@"Resources\Files\dishes.csv");
                var document = new XDocument();
                var dishes = new XElement("Dishes", records.Select(x =>
                new XElement("Dish",
                new XAttribute("Name", x.Name),
                new XAttribute("Calories", x.Calories),
                new XAttribute("Carbs", x.Carbs),
                new XAttribute("Fat", x.Fat),
                new XAttribute("Proteins", x.Proteins)
                )));

                document.Add(dishes);
                document.Save("dishes.xml");
                Console.WriteLine("\n Dummy dish data has been saved in xml file\n");
                Console.ReadKey();
            }
            else if(description == "Ingredients")
            {
                var records = _csvReader.ProcessIngredients(@"Resources\Files\ingredients.csv");
                var document = new XDocument();
                var ingredients = new XElement("Ingredients", records.Select(x =>
                new XElement("Ingredient",
                new XAttribute("Name", x.Name),
                new XAttribute("Calories", x.Calories),
                new XAttribute("Carbs", x.Carbs),
                new XAttribute("Fat", x.Fat),
                new XAttribute("Proteins", x.Proteins)
                )));

                document.Add(ingredients);
                document.Save("ingredients.xml");
                Console.WriteLine("\n Dummy ingredients data has been saved in xml file\n");
                Console.ReadKey();
            }
            else
            {
                var records = _csvReader.ProcessRecipes(@"Resources\Files\recipes.csv");
                var document = new XDocument();
                var recipes = new XElement("Recipes", records.Select(x =>
                new XElement("Recipes",
                new XAttribute("Name", x.Name),
                new XAttribute("Ingredient1", x.Ingredient1), 
                new XAttribute("Ingredient2", x.Ingredient2),
                new XAttribute("Ingredient3", x.Ingredient3),
                new XAttribute("Ingredient4", x.Ingredient4),
                new XAttribute("Ingredient5", x.Ingredient5)
                )));

                document.Add(recipes);
                document.Save("recipes.xml");
                Console.WriteLine("\n Dummy recipes data has been saved in xml file\n");
                Console.ReadKey();
            }
        }

        public void QueryXml()
        {
            var document = XDocument.Load("dishes.xml");
            var names = document.Element("Dishes")?.Elements("Dishes")
                .Where(x => x.Attribute("Name")?.Value == "Sałatka meksykańska")
                .Select(x => x.Attribute("Name")?.Value);

            foreach(var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
