using Domain;
using Microsoft.EntityFrameworkCore;
using PMRepository.IRepositories;

namespace PMRepository.Repositories
{
    public class Repository4Project<CTX> : Repository<Project, CTX>, IRepository4Project
        where CTX : DbContext
    {
        public Repository4Project(IUnitOfWork<CTX> uow) : base(uow)
        {
        }
    }
}