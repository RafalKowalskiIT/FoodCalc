using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Entities
{
    public class Dish : EntityBase
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Proteins { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }  
        public int Price { get; set; }
        public override string ToString() => $"Id: {ID}, Name: {Name}, Kcal: {Calories}, B: {Proteins}, W: {Carbs}, T: {Fat}";
    }
}

