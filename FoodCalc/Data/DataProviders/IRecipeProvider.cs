using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.DataProviders
{
    public interface IRecipeProvider
    {
        List<string> GetRecipesByIngredient(string searchIngredient);
        List<string> GetUniqueIngredients();
    }
}
