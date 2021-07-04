using System.Collections.Generic;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    // out covariance rzutowanie w górę
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);
    }

    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
            where T : IEntityBase
    {
    }

    // in czyli rzutowanie w doł
    public interface IWriteRepository<in T>
    {
        void Add(T item);

        void Remove(T item);

        void Save();
    }
}