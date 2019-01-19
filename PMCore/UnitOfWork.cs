using System;
using Microsoft.EntityFrameworkCore;

namespace PMRepository
{
    public class UnitOfWork<CTX>:IUnitOfWork<CTX>
        where CTX:DbContext
    {
        public UnitOfWork(CTX context)
        {
            Context = context;
        }

        public CTX Context { get; }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
