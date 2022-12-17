﻿using FoodCalc.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodCalc.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _dbContex;
        private readonly Action<T>? _itemAddedCallback;

        public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
        {
            _dbContex = dbContext;
            _dbSet = dbContext.Set<T>();
            _itemAddedCallback = itemAddedCallback;
        }

        public event EventHandler<T> ItemAdded;
        public event EventHandler<T> ItemRemoved;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(int ID)
        {
            return _dbSet.Find(ID);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);
            ItemAdded?.Invoke(this, item);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            ItemRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContex.SaveChanges();
        }
    }
}

