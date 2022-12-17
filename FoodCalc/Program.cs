using FoodCalc.Data;
using FoodCalc.Entities;
using FoodCalc.Repositories;
using FoodCalc.Repositories.Extensions;


var dishRepository = new SqlRepository<Dish>(new FoodCalcAppDbContext(), DishAdded);
dishRepository.ItemAdded += DishRepository_ItemAdded;
dishRepository.ItemRemoved += DishRepository_ItemRemoved;

void DishRepository_ItemRemoved(object? sender, Dish e)
{
    Console.WriteLine($"Dish removed => {e.Name} from {sender?.GetType().Name}" );
}

void DishRepository_ItemAdded(object? sender, Dish e)
{
    Console.WriteLine($"Dish added => {e.Name} from {sender?.GetType().Name}");
}



AddDish(dishRepository);

static void DishAdded(Dish item)
{
    Console.WriteLine($"{item.Name} added");
}

static void AddDish(IRepository<Dish> dishRepository)
   
{
    var dishes = new[]
    {
        new Dish { Name = "Pizza" },
        new Dish { Name = "Omlet" },
        new Dish { Name = "Eggs" },

    };

    dishRepository.AddBatch(dishes);
    

}

