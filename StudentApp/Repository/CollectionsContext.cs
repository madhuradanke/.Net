using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using BOL;
namespace StudentApp.Repository
{
    public class CollectionsContext: DbContext
    {
        public CollectionsContext()
        {
        }

        public DbSet<BOL.Student> students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string con = @"server=localhost;port=3306;user=root;password=root123;database=netprac";
            optionsBuilder.UseMySQL(con);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BOL.Student>(entity =>
            {
                entity.HasKey(x => x.student_id);
                entity.Property(x => x.student_name).IsRequired();
                entity.Property(x => x.Email).IsRequired();
                entity.Property(x => x.Mobile).IsRequired();
                entity.Property(x => x.Fees).IsRequired();
                entity.Property(e => e.Status)
                   .HasConversion(v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v));
                entity.Property(x => x.Address).IsRequired();
                entity.Property(x=> x.admission_date)
             .HasConversion(
                 v => v.ToDateTime(TimeOnly.MinValue),
                 v => DateOnly.FromDateTime(v))
             .HasColumnType("date");
            });
            modelBuilder.Entity<BOL.Student>().ToTable("student");
        }


    }
}
