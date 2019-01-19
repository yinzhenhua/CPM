using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;

namespace PMRepository.Repositories
{
    public abstract class Repository<T,CTX>:IRepository<T>
        where T:BaseEntity
        where CTX:DbContext
    {
        private readonly IUnitOfWork<CTX> _unitOfWork;

        protected Repository(IUnitOfWork<CTX> uow)
        {
            _unitOfWork = uow;
        }

        protected CTX Context => _unitOfWork.Context;
        protected DbSet<T> Set => Context.Set<T>();

        public void Add(T item)
        {
            Set.Add(item);
        }

        public T Find(string key)
        {
            return Set.Find(key);
        }

        public void Remove(string key)
        {
            var t = Find(key);
            Set.Remove(t);
        }

        public void Update(T item)
        {
            Context.Entry<T>(item);
        }

        public string GetKey()
        {
            return BitConverter.ToString(Guid.NewGuid().ToByteArray())
                               .Replace("-", string.Empty)
                               .ToUpper();
        }
    }
}
