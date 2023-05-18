
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodCalc.Data.DataProviders
{
    public class DishesProvider : IDishesProvider
    {
        private readonly IRepository<Dish> _dishRepository;

        public DishesProvider(IRepository<Dish> dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public List<Dish> OrderByCalories()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.OrderBy(dishes => dishes.Calories).ThenBy(dishes => dishes.Name).ToList();
        }

        public List<Dish> OrderByName()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.OrderBy(dishes => dishes.Name).ToList();
        }
        public List<Dish> OrderByFat()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.OrderBy(dishes => dishes.Fat).ThenBy(dishes => dishes.Name).ToList();
        }
        public List<Dish> OrderByProteins()
        {
            var dishes = _dishRepository.GetAll();
            return dishes.OrderBy(dishes => dishes.Proteins).ThenBy(dishes => dishes.Name).ToList();
        }

    }
}
