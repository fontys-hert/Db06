using Db06.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db06.DataAccess
{
    // De DbContext is eigenlijk de brug tussen je c# code en een database

    public class Db06Context : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public Db06Context(DbContextOptions<Db06Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property("Pin");
                entity.Property("Balance");
            });
        }
    }
}
