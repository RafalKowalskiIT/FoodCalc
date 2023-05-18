using FoodCalc;
using FoodCalc.Components.CsvReader;
using FoodCalc.Data;
using FoodCalc.Data.DataProviders;
using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;
using FoodCalc.Data.XmlHandler;
using Microsoft.Extensions.DependencyInjection;
using FoodCalc.UI;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IRepository<Dish>, SqlRepository<Dish>>();
services.AddSingleton<IDishesProvider, DishesProvider>();
services.AddSingleton<IIngredientsProvider, IngredientsProvider>();
services.AddSingleton<IRecipeProvider, RecipeProvider>();
services.AddSingleton<IRepository<Ingredients>, SqlRepository<Ingredients>>();
services.AddSingleton<IRepository<Recipe>,  SqlRepository<Recipe>>();
services.AddSingleton<IMainMenuHandler, MainMenuHandler>();
services.AddSingleton<IDishMenuHandler, DishMenuHandler>();
services.AddSingleton<IIngredientsMenuHandler, IngredientsMenuHandler>();
services.AddSingleton<IRecipeMenuHandler, RecipeMenuHandler>();
services.AddSingleton<IDishesDetailsHandler, DishesDetailsHandler>();
services.AddSingleton<IIngredientsDetailsHandler, IngredientsDetailsHandler>();
services.AddSingleton<IRecipeDetailsHandler, RecipeDetailsHandler>();
services.AddSingleton<IEventsHandler, EventsHandler>();
services.AddSingleton<IXmlHandler, XmlHandler>();
services.AddSingleton<IXmlMenuHandler, XmlMenuHandler>();
services.AddSingleton<IDataHandler, DataHandler>();


services.AddSingleton<ICsvReader, CsvReader>();
services.AddDbContext<FoodCalcAppDbContext>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>()!;
app.Run();
