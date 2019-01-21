using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;

namespace PMRepository.Repositories
{
    public class Repository4ActionGroup<CTX> : Repository<ActionGroup, CTX>, IRepository4ActionGroup
        where CTX : DbContext
    {
        public Repository4ActionGroup(IUnitOfWork<CTX> uow) : base(uow)
        {
        }
    }
}