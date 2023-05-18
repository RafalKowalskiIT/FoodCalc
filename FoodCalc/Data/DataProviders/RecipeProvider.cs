using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;

namespace FoodCalc.Data.DataProviders
{
    public class RecipeProvider : IRecipeProvider
    {
        private readonly IRepository<Recipe> _recipeRepository;

        public RecipeProvider(IRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public List<string> GetRecipesByIngredient(string searchIngredient)
        {
            var recipes = _recipeRepository.GetAll();
            var matchingDishes = recipes
                .Where(r =>
                    !string.IsNullOrEmpty(r.Name) &&
                    (r.Ingredient1.Contains(searchIngredient) ||
                    r.Ingredient2.Contains(searchIngredient) ||
                    r.Ingredient3.Contains(searchIngredient) ||
                    r.Ingredient4.Contains(searchIngredient)))
                .Select(r => r.Name)
                .Distinct()
                .ToList();

            return matchingDishes;
        }

        public List<string> GetUniqueIngredients()
        {
            var recipes = _recipeRepository.GetAll();
            var allIngredients = recipes
                .SelectMany(r => new[] { r.Ingredient1, r.Ingredient2, r.Ingredient3, r.Ingredient4 })
                .Where(i => !string.IsNullOrEmpty(i))
                .Distinct()
                .ToList();

            return allIngredients;
        }

    }
}
