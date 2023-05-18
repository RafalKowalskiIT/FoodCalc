using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.DataProviders
{
    public interface IIngredientsProvider
    {
        List<Ingredients> OrderByCalories();
        List<Ingredients> OrderByProteins();
        List<Ingredients> OrderByFat();
        List<Ingredients> OrderByCarbs();
        List<Ingredients> OrderByName();

    }
}
