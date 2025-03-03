using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
namespace OnlineShop.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Product settings
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)")
                .HasDefaultValue(0);
            modelBuilder.Entity<Product>()
                .ToTable(t =>
                {
                    t.HasCheckConstraint("CK_Product_MaxValue", "[Price] <= 999999");
                    t.HasCheckConstraint("CK_Quantity_MaxValue", "[Quantity] < 10000");
                });
            modelBuilder.Entity<Product>().HasOne(s => s.Shop).WithMany(p => p.Products).HasForeignKey(p => p.ShopId).OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region Shop settings
            modelBuilder.Entity<Shop>().HasKey(s => s.Id);
            modelBuilder.Entity<Shop>().Property(s => s.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Shop>().HasOne(s => s.Manager).WithOne(u => u.ManagedShop).HasForeignKey<Shop>(u => u.ManagerId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shop>().HasMany(s => s.Employees).WithOne(u => u.Shop).HasForeignKey(u => u.ShopId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Shop>().HasMany(s => s.Products).WithOne(p => p.Shop).HasForeignKey(p => p.ShopId).OnDelete(DeleteBehavior.Cascade);
            #endregion
            #region User settings
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Ignore(u => u.Shop);
            #endregion
        }
    }
}
