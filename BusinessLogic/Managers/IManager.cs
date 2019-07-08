using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Managers
{
    public interface IManager<T>
    {
        IEnumerable<T> GetAll();
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(T item);
    }
}
