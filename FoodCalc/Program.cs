using FoodCalc.Data;
using FoodCalc.Entities;
using FoodCalc.Repositories;
using FoodCalc.Repositories.Extensions;
using System.Drawing;
using System.Text;

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

Console.OutputEncoding = Encoding.UTF8;
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;

string text = "Welcome to the Food Calculator App!\n";
string text2 = "Please choose your action\n" +
    "1. Add new dishes\n" +
    "2. Add new ingridients\n" +
    "3. Collect your diet\n";
string text3 = "Search your dish by nutrients\n" +
    "1. By protein\n" +
    "2. By carbs\n" +
    "3. By fat\n";

PrintLinesInCenter(text);
Console.ReadKey();
Console.Clear();
PrintLinesInCenter(text2);
var input = Console.ReadLine();
switch (input)
{
    case "1":
        Console.Clear();
        AddDish(dishRepository);
        return;
    case "2":
        return;
    case "3":
        Console.Clear();
        PrintLinesInCenter(text3);
        return;
    default:
        Console.WriteLine("Incorrect command");
        return;
}

Console.ReadKey();

static void DishAdded(Dish item)
{
    Console.WriteLine($"{item.Name} added");
}

static void AddDish(IRepository<Dish> dishRepository)

{
    var dishes = new[]
    {
        new Dish { Name = "Pizza", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },
        new Dish { Name = "Omlet", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },
        new Dish { Name = "Eggs", Calories = 400, Carbs = 100, Fat = 50, Proteins = 100, Price = 5, },

    };

    dishRepository.AddBatch(dishes);
}

static void PrintLinesInCenter(params string[] lines)
{
    int verticalStart = (Console.WindowHeight - lines.Length) / 2;
    int verticalPosition = verticalStart;
    foreach (var line in lines)
    {        
        int horizontalStart = (Console.WindowWidth - line.Length) / 2;        
        Console.SetCursorPosition(horizontalStart, verticalPosition);        
        Console.Write(line);        
        ++verticalPosition;
    }
}