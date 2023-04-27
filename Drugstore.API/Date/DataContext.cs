using Microsoft.EntityFrameworkCore;
using Drugstore.Shared.Entities;
using Drugstore.Shared.Entities.Medicamento;
using Drugstore.Shared.Entities.Medicine;
//using Drugstore.Shared.Entities.Usuario;
//using Drugstore.Shared.Entities.Venta;


namespace Drugstore.API.Date
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //Medicamento
        public DbSet<Category> Categories { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<MedicineCategory> MedicineCategories { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        



        //Venta
        //public DbSet<MedicalOrder> MedicalOrders { get; set; }
        //public DbSet<Sale> Sales { get; set; }




        //Usuario
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Medicine>().HasIndex("CategoryId","Name").IsUnique();
            modelBuilder.Entity<MedicineCategory>().HasIndex("MedicineId", "Name").IsUnique();
        
            //ORDENES

        //modelBuilder.Entity<MedicalOrder>().HasIndex(x => x.order_id).IsUnique();
        //MedicineImagne, cómo sería? 
        //modelBuilder.Entity<Sale>().HasIndex(x => x.sale_id).IsUnique();
        //modelBuilder.Entity<User>().HasIndex(x => x.user_name).IsUnique();
        //modelBuilder.Entity<Role>().HasIndex(d => d.role_name).IsUnique();

        

        }
    }
}
