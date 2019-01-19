using System;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> contextOptions):base(contextOptions)
        {
        }

        public virtual DbSet<CodeMap> CodeMaps { get; set; }
    }
}
