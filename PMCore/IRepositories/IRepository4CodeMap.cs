using System;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace PMRepository.IRepositories
{
    public interface IRepository4CodeMap:IRepository<CodeMap>
    {
        IQueryable<CodeMap> GetQueryable(Expression<Func<CodeMap, bool>> expression=null);
    }
}
