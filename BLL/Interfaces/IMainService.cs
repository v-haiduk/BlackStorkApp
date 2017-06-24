using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IMainService<T>
    {
        IEnumerable<T> GetAllElements();
        IEnumerable<T> FindElement(Expression<Func<T, Boolean>> predicate);
        T GetElement(int? id);
        void CreateElement(T element);
        void UpdateElement(T element);
        void DeleteElement(int? id);
        void Dispose();
    }
}
