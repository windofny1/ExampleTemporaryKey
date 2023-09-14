using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemporalKey.Domain.UserAggregate;

namespace TemporalKey.Infastracture.Persistence.DbContexts
{
    public class TemporalKeyDbContext:DbContext
    {
        
        public TemporalKeyDbContext(DbContextOptions<TemporalKeyDbContext> options)

         : base(options)

        {
            
        }
        public DbSet<User> Users { get; set; } = null!;

        //public DbSet<UserData> UserData { get; set; } = null!;
        //public DbSet<EventLog> EventLog { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.                
                ApplyConfigurationsFromAssembly(typeof(TemporalKeyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            base.OnConfiguring(optionsBuilder);
        }
    }
}
