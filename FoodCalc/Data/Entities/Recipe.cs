﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.Entities
{
    public class Recipe : EntityBase
    {
        public string Name { get; set; }
        public string Ingredient1 { get; set; }
        public string Ingredient2 { get; set; }
        public string Ingredient3 { get; set; }
        public string Ingredient4 { get; set; }
        public string Ingredient5 { get; set; }
    }
}
