using System;
using System.Collections.Generic;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T budget);
        T Read(Func<T, bool> predicate);
        List<T> ReadAll();
    }
}