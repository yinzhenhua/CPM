using System;
using Microsoft.EntityFrameworkCore;

namespace PMRepository
{
    public interface IUnitOfWork<CTX>:IDisposable
        where CTX:DbContext
    {
        void Commit();

        CTX Context { get; }
    }
}
