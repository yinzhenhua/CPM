using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;

namespace PMRepository.Repositories
{
    public class Repository4SecurityKey<CTX> : Repository<SecurityKey, CTX>, IRepository4SecurityKey
        where CTX : DbContext
    {
        public Repository4SecurityKey(IUnitOfWork<CTX> uow) : base(uow)
        {
        }
    }
}