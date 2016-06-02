using System.Collections.Generic;

namespace SimpleWebApp.Domain.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        void Update(T item);
        void Remove(int id);
    }
}