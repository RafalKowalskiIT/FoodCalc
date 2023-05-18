using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.DataProviders
{
    public class IngredientsProvider : IIngredientsProvider
    {
        private readonly IRepository<Ingredients> _ingredientsRepository;

        public IngredientsProvider(IRepository<Ingredients> ingredientsRepository) 
        {
            _ingredientsRepository = ingredientsRepository;         
        }
        public List<Ingredients> OrderByCalories()
        {
            var ingredients = _ingredientsRepository.GetAll();
            return ingredients.OrderBy(ingredients => ingredients.Calories).ThenBy(ingredients => ingredients.Name).ToList();
        }

        public List<Ingredients> OrderByCarbs()
        {
            var ingredients = _ingredientsRepository.GetAll();
            return ingredients.OrderBy(ingredients => ingredients.Carbs).ThenBy(ingredients => ingredients.Name).ToList();
        }

        public List<Ingredients> OrderByFat()
        {
            var ingredients = _ingredientsRepository.GetAll();
            return ingredients.OrderBy(ingredients => ingredients.Fat).ThenBy(ingredients => ingredients.Name).ToList();
        }

        public List<Ingredients> OrderByName()
        {
            var ingredients = _ingredientsRepository.GetAll();
            return ingredients.OrderBy(ingredients => ingredients.Name).ToList();
        }

        public List<Ingredients> OrderByProteins()
        {
            var ingredients = _ingredientsRepository.GetAll();
            return ingredients.OrderBy(ingredients => ingredients.Proteins).ThenBy(ingredients => ingredients.Name).ToList();
        }
    }
}
