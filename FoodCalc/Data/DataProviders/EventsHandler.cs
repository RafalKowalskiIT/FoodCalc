using FoodCalc.Data.Entities;
using FoodCalc.Data.Repositories;


namespace FoodCalc.Data.DataProviders
{
    public class EventsHandler : IEventsHandler
    {
        private readonly IRepository<Dish> _dishRepository;
        private readonly IRepository<Ingredients> _ingredientsRepository;
        private readonly IRepository<Recipe> _recipeRepository;

        public EventsHandler(IRepository<Dish> dishRepository, IRepository<Ingredients> ingredientsRepository, IRepository<Recipe> recipeRepository)
        {
            _dishRepository = dishRepository;
            _ingredientsRepository = ingredientsRepository;
            _recipeRepository = recipeRepository;
        }

        public void SubscribeToEvents()
        {
            _dishRepository.ItemAdded += DishRepositoryOnItemAdded;
            _dishRepository.ItemRemoved += DishRepositoryOnItemRemoved;

            _ingredientsRepository.ItemAdded += IngredientRepositoryOnItemAdded;
            _ingredientsRepository.ItemRemoved += IngredientRepositoryOnItemRemoved;

            _recipeRepository.ItemAdded += RecipeRepositoryOnItemAdded;
            _recipeRepository.ItemRemoved += RecipeRepositoryOnItemRemoved;
        }

        private void DishRepositoryOnItemAdded(object? sender, Dish e) 
        {
            _dishRepository.SaveToAuditFile("Dish Added", e);
        }
        private void DishRepositoryOnItemRemoved(object? sender, Dish e)
        {
            _dishRepository.SaveToAuditFile("Dish Removed", e);
        }
        private void IngredientRepositoryOnItemAdded(object? sender, Ingredients e)
        {
            _ingredientsRepository.SaveToAuditFile("Ingredient Added", e);
        }
        private void IngredientRepositoryOnItemRemoved(object? sender, Ingredients e)
        {
            _ingredientsRepository.SaveToAuditFile("Ingredient Removed", e);
        }
        private void RecipeRepositoryOnItemAdded(object? sender, Recipe e)
        {
            _recipeRepository.SaveToAuditFile("Recipe Added", e);
        }
        private void RecipeRepositoryOnItemRemoved(object? sender, Recipe e)
        {
            _recipeRepository.SaveToAuditFile("Recipe Removed", e);
        }
    }
}
