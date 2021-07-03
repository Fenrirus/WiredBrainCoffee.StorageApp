using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class ListRepository<T, TKey> : IRepository<T>
        where T : class, IEntityBase
        where TKey : struct
    {
        protected readonly List<T> _items = new();
        public TKey? Key { get; set; }

        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        //public T CreateItem()
        //{
        //    return new T();
        //}

        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            //foreach (var item in _items)
            //{
            //    Console.WriteLine(item);
            //}
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