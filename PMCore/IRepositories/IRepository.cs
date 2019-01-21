using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace PMRepository.IRepositories
{
    public interface IRepository<T>
        where T:BaseEntity

    {
        void Add(T item);

        void Remove(string key);

        void Update(T item);

        T Find(string key);

        IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression = null);

        string GetKey();
    }
}
