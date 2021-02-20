
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kawanso.WebApi.Models
{
    public class DBContext : DbContext
    {
        public DBContext()
             : base("Kowanso")
        {
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Task>().ToTable("Task");
        }
    }

    
}
