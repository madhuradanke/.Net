using BOL;
using Microsoft.EntityFrameworkCore;

namespace DAL

{
    public class CollectionContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"server=localhost;port=3306;user=root;password=root123;database=product";
            optionsBuilder.UseMySQL(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.pid);
                entity.Property(e => e.Pname).IsRequired();
                entity.Property(e => e.Qty).IsRequired();
                entity.Property(e=>e.Price).IsRequired();
            });
            modelBuilder.Entity<Product>().ToTable("product");
        }
    }
}
