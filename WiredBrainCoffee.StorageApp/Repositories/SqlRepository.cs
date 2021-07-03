using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<T, TKey> : IRepository<T> where T : class, IEntityBase
        where TKey : struct
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public TKey? Key { get; set; }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        //public T CreateItem()
        //{
        //    return new T();
        //}

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(o => o.Id).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }

    //public class GenericRepositoryRemove<T, TKey> : GenericRepository<T, TKey>
    //{
    //    public void Remove(T item)
    //    {
    //        _items.Remove(item);
    //    }
    //}
}