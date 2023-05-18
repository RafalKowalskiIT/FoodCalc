using FoodCalc.Data;
using FoodCalc.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using FoodCalc.Data.DataProviders;


namespace FoodCalc.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly FoodCalcAppDbContext _dbContex;
        private const string auditFileName = $@"C:\Users\IT\PracaDomowa\FoodCalc\FoodCalc\Data\Audit\Audit.txt";
        private const string jsonFilePath = $@"C:\Users\IT\PracaDomowa\FoodCalc\FoodCalc\Data\Audit\";
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemoved;

        public SqlRepository(FoodCalcAppDbContext dbContext)
        {
            _dbContex = dbContext;
            _dbSet = dbContext.Set<T>();           
        }


        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetByID(int ID)
        {
            return _dbSet.Find(ID);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _dbContex.SaveChanges();
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            _dbContex.SaveChanges();
            ItemRemoved?.Invoke(this, item);
        }

        public void Save(string description)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            using (var writer = File.AppendText($"{jsonFilePath}{description} - [{date}]" + ".json"))
            {
                foreach (var item in _dbSet)
                {
                    string employee = JsonSerializer.Serialize(item);
                    writer.WriteLine(employee);
                }
            }
            Console.WriteLine($"\n--- All data has been saved in json file ---");
        }

        public void SaveToAuditFile(string description, T e)
        {
            DateTime actualTime = DateTime.Now;
            using (var auditWriter = File.AppendText(auditFileName))
            {
                auditWriter.WriteLine($"{actualTime} - {description} - {e}");
            }
        }
    }
}

