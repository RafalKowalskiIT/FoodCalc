using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc
{
    public class App : IApp
    {
        private readonly IRepository<Dish> _dishRepository;

        public App(IRepository<Dish> dishRepository)
        {
            _dishRepository = dishRepository;
        }
        public void Run()
        {
            Console.WriteLine("Hi, I'm here");

            var dishes = new[]
            {
                new Dish { Name = "Pizza", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },
                new Dish { Name = "Omlet", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },
                new Dish { Name = "Eggs", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },

             };

            foreach (var dish in dishes)
            {
                _dishRepository.Add(dish);
            }

            _dishRepository.Save();

            var items = _dishRepository.GetAll();
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
