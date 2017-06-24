using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.Interfaces
{
    /// <summary>
    /// The generalized interface for work with DB.
    /// This interface encapsulates a logic to work with DB.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllElements();
        T GetElement(int id);
        IEnumerable<T> FindElement(Expression<Func<T, Boolean>> predicate);
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
