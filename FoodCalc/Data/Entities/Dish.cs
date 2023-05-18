using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.Entities
{
    public class Dish : EntityBase
    {
        public string? Name { get; set; }
        public double Calories { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public double Proteins { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Id: {ID}");
            sb.AppendLine($"   Name: {Name}  Calories: {Calories}");
            sb.AppendLine($"   Macronutrients: W {Carbs}g T {Fat}g B {Proteins}g");

            return sb.ToString();
        }
    }
}

