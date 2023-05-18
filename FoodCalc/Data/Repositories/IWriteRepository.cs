using FoodCalc.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodCalc.Data.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void Save(string description);
        void SaveToAuditFile(string description, T e);
    }
}
