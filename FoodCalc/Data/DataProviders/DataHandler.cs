using FoodCalc.Components.CsvReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.DataProviders
{
    internal class DataHandler : IDataHandler
    {
        private FoodCalcAppDbContext _dbContext;
        private ICsvReader _csvReader;

        public DataHandler(FoodCalcAppDbContext dbContext, ICsvReader csvReader) 
        {
            _dbContext = dbContext;
            _csvReader = csvReader;
        }
        public void AddDishes()
        {
            if (!_dbContext.Dishes.Any())
            {
                var dishes = _csvReader.ProcessDish(@"Resources\Files\dishes.csv");
                _dbContext.Dishes.AddRange(dishes);
                _dbContext.SaveChanges();
            }
        }

        public void AddIngredients()
        {
            if (!_dbContext.Dishes.Any())
            {
                var ingredients = _csvReader.ProcessDish(@"Resources\Files\ingredients.csv");
                _dbContext.Dishes.AddRange(ingredients);
                _dbContext.SaveChanges();
            }
        }

        public void AddRecipes()
        {
            if (!_dbContext.Dishes.Any())
            {
                var recipes = _csvReader.ProcessDish(@"Resources\Files\recipes.csv");
                _dbContext.Dishes.AddRange(recipes);
                _dbContext.SaveChanges();
            }
        }
    }
}
