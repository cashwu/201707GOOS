﻿namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T enity);
    }
}