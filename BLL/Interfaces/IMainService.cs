using System;
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IMainService<T>
    {
        IEnumerable<T> GetAllElements();
        T GetElement(int? id);
        void Dispose();
    }
}
