using Microsoft.EntityFrameworkCore;
using Drugstore.Shared.Entities.Medicamento;
using Drugstore.Shared.Entities.Usuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Drugstore.Shared.Entities;



namespace Drugstore.API.Date
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Medicamento
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
      
        public DbSet<MedicineCategory> MedicineCategories { get; set; }

        public DbSet<MedicineImage> MedicineImages { get; set; }

        public DbSet<User> Users { get; set; }


        //Venta
        //public DbSet<MedicalOrder> MedicalOrders { get; set; }
        //public DbSet<Sale> Sales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Medicine>().HasIndex(c => c.Name).IsUnique();

        }
    }
}
