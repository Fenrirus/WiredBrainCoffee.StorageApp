using System;
using System.Collections.Generic;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class GenericRepository<T, TKey>
    {
        protected readonly List<T> _items = new();
        public TKey? Key { get; set; }

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class GenericRepositoryRemove<T, TKey> : GenericRepository<T, TKey>
    {
        public void Remove(T item)
        {
            _items.Remove(item);
        }
    }
}