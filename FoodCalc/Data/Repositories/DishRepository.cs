using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodCalc.Data.Entities;

namespace FoodCalc.Data.Repositories
{
    public class DishRepository<T> : IRepository<T> 
        where T : class, IEntity
    {
        private readonly List<T> _items = new();

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetByID(int ID)
        {
            return _items.Single(item => item.ID == ID);
        }

        public void Add(T item)
        {
            item.ID = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {

        }
    }
}
