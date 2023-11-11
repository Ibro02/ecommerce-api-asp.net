
global using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Salesman>()
                .HasAlternateKey(x => new { x.SalesmanId, x.ProductId });

            modelBuilder.Entity<Models.Order>()
                .HasAlternateKey(x => new { x.Id, x.CustomerId, x.ProductId });

           modelBuilder.Entity<Models.Comment>()
               .HasAlternateKey(x => new { x.Id, x.UserId, x.ProductId });

            modelBuilder.Entity<Models.ProductImage>()
                .HasAlternateKey(x => new { x.ProductId, x.ImageId });
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Models.User> Users => Set<Models.User>();

        public DbSet<Models.Role> Roles => Set<Models.Role>();

        public DbSet<Models.City> Cities => Set<Models.City>();

        public DbSet<Models.Country> Countries => Set<Models.Country>(); 
        
        public DbSet<Models.Product> Products => Set<Models.Product>();

        public DbSet<Models.Status> Statuses => Set<Models.Status>();

        public DbSet<Models.Salesman> Salesmen => Set<Models.Salesman>();

        public DbSet<Models.ProductCategory> Categories => Set<Models.ProductCategory>();

        public DbSet<Models.Order> Orders => Set<Models.Order>();

      public DbSet<Models.Comment> Comments => Set<Models.Comment>();

        public DbSet<Models.Image> Images => Set<Models.Image>();

        public DbSet<Models.ProductImage> ProductImages => Set<Models.ProductImage>();





    }
}
