﻿using System.Collections.Generic;

namespace SimpleWebApp.Domain.Abstract
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Update(T item);
        void Remove(int id);
    }
}