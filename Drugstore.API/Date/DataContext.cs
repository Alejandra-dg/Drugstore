using Drugstore.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Data;
using Microsoft.Extensions.Hosting;
using Drugstore.API.Controllers;

namespace Drugstore.API.Date
{
    public class DataContext : DbContext
    {
        public DbSet<MedicalOrder> MedicalOrders { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(x => x.user_id).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(d => d.role_id).IsUnique();

        }

    }
}
