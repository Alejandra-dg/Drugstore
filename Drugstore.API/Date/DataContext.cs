using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Data;
using Microsoft.Extensions.Hosting;
using Drugstore.API.Controllers;
using Drugstore.Shared.Entities.Usuario;
using Drugstore.Shared.Entities.Venta;
using Drugstore.Shared.Entities.Medicamento;

namespace Drugstore.API.Date
{
    public class DataContext : DbContext
    {
        //Medicamento
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineCategory> MedicineCategories { get; set; }
        public DbSet<MedicineImage>MedicineImages { get; set; }



        //Venta
        public DbSet<MedicalOrder> MedicalOrders { get; set; }
        public DbSet<Sale> Sales { get; set; }




        //Usuario
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(x => x.category_name).IsUnique();
            modelBuilder.Entity<Medicine>().HasIndex(x => x.medicine_name).IsUnique();
            modelBuilder.Entity<MedicalOrder>().HasIndex(x => x.order_id).IsUnique();
            //MedicineImagne, cómo sería? 
            modelBuilder.Entity<Sale>().HasIndex(x => x.sale_id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.user_name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(d => d.role_name).IsUnique();

        }

    }
}
