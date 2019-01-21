using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;

namespace PMRepository.Repositories
{
    public class Repository4CodeMap<CTX> : Repository<CodeMap, CTX>, IRepository4CodeMap
        where CTX:DbContext
    {
        public Repository4CodeMap(IUnitOfWork<CTX> uow) : base(uow)
        {
        }
    }
}
