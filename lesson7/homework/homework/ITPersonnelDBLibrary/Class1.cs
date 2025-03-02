using Microsoft.EntityFrameworkCore;

namespace ITPersonnelDBLibrary {
    public class Employees {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }
        public Departments DepartmentId { get; set; }
    }

    public class Departments {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
    }


    public class ITPersonalContext: DbContext {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

        public ITPersonalContext() {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Employees>().Property(p => p.FirstName).HasMaxLength(20);
            modelBuilder.Entity<Employees>().Property(p => p.LastName).HasMaxLength(20);
            modelBuilder.Entity<Employees>().Property(p => p.FirstName).IsUnicode(false);
            modelBuilder.Entity<Employees>().Property(p => p.LastName).IsUnicode(false);
            modelBuilder.Entity<Employees>().Property(p => p.Email).IsUnicode(true);

            modelBuilder.Entity<Employees>().Property(u => u.Age).HasDefaultValue(18);
            modelBuilder.Entity<Employees>()
            .ToTable(t => t.HasCheckConstraint("Age", "Age > 0 AND Age < 120"));

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-31VSBGAE;Database=ITPersonalDB;Integrated Security=SSPI;TrustServerCertificate=true");

        }
    }
}
