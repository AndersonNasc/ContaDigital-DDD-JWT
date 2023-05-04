using Entity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options): base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConn());
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public string GetStringConn()
        {
            return "Data Source=DESKTOP-4GIQV0F;Initial Catalog=ContaDigital;Integrated Security=True;encrypt=false";
        }

     }
}
