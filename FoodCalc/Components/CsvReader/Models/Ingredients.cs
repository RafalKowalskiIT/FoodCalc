using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Components.CsvReader.Models
{
    public class Ingredients
    {
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Proteins { get; set; }
    }
}
