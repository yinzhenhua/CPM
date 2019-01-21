using System;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions contextOptions):base(contextOptions)
        {
        }

        public virtual DbSet<CodeMap> CodeMaps { get; set; }
        
        public virtual DbSet<Project> Projects { get; set; }
    }
}
