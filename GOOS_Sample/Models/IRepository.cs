using System;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T budget);
        T Read(Func<T, bool> any);
    }
}