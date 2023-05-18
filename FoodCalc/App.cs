using FoodCalc.Components.CsvReader;
using FoodCalc.Data;
using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using FoodCalc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc
{
    public class App : IApp
    {
        private readonly IDataHandler _dataHandler;
        private readonly FoodCalcAppDbContext _foodCalcAppDbContext;
        private readonly IMainMenuHandler _mainMenuHandler;
        private readonly IEventsHandler _eventsHandler;
        public App(FoodCalcAppDbContext foodCalcAppDbContext, IMainMenuHandler mainMenuHandler, IEventsHandler eventsHandler, IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
            _eventsHandler = eventsHandler;
            _mainMenuHandler = mainMenuHandler;
            _foodCalcAppDbContext = foodCalcAppDbContext;
            _foodCalcAppDbContext.Database.EnsureCreated();
        }
        public void Run()
        {
            Console.WriteLine("\n***** Welcome *****\n");
            _eventsHandler.SubscribeToEvents();
            _dataHandler.AddDishes();
            _dataHandler.AddIngredients();
            _dataHandler.AddRecipes();
            _mainMenuHandler.SelectMainOption();

            

        }

    }
}
