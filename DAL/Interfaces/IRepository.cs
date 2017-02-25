using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllElements();
        T GetElement(int id);
        IEnumerable<T> FindElement(Func<T, Boolean> predicate);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
