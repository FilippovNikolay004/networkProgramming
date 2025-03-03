using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace AcademicLibrary {
    public class Subjects {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Lectures> Lectures { get; set; } = new List<Lectures>();
    }
    public class Teachers {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Salary { get; set; }

        public ICollection<Lectures> Lectures { get; set; } = new List<Lectures>();
    }
    public class Curators {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public ICollection<GroupsCurators> GroupsCurator { get; set; } = new List<GroupsCurators>();
    }
    public class Faculties {
        public int Id { get; set; }
        public int Financing { get; set; }
        public string Name { get; set; }

        public ICollection<Departments> Departments { get; set; } = new List<Departments>();
    }


    public class Departments {
        public int Id { get; set; }
        public int Financing { get; set; }
        public string Name { get; set; }

        public int FacultyId { get; set; }
        public Faculties Faculty { get; set; }

        public ICollection<Groups> Groups { get; set; } = new List<Groups>();
    }
    public class Groups {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }

        public int DepartmentId { get; set; }
        public Departments Department { get; set; }

        public ICollection<GroupsLectures> GroupsLecture { get; set; } = new List<GroupsLectures>();
        public ICollection<GroupsCurators> GroupsCurator { get; set; } = new List<GroupsCurators>();
    }


    public class GroupsLectures {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Groups Group { get; set; }

        public int LectureId { get; set; }
        public Lectures Lecture { get; set; }
    }
    public class Lectures {
        public int Id { get; set; }

        public int SubjectId { get; set; }
        public Subjects Subject { get; set; }

        public int TeacherId { get; set; }
        public Teachers Teacher { get; set; }

        public ICollection<GroupsLectures> GroupsLectures { get; set; } = new List<GroupsLectures>();
    }
    public class GroupsCurators {
        public int Id { get; set; }

        public int CuratorId { get; set; }
        public Curators Curator { get; set; }

        public int GroupId { get; set; }
        public Groups Group { get; set; }
    }


    public class AcademicContext : DbContext {
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Curators> Curators { get; set; }
        public DbSet<Faculties> Faculties { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupsLectures> GroupsLectures { get; set; }
        public DbSet<Lectures> Lectures { get; set; }
        public DbSet<GroupsCurators> GroupsCurators { get; set; }


        static DbContextOptions<AcademicContext> _options;

        static AcademicContext() {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademicContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Subjects>().Property(p => p.Name).IsRequired();


            modelBuilder.Entity<Teachers>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Teachers>().Property(p => p.SurName).IsRequired();
            modelBuilder.Entity<Teachers>().Property(p => p.Salary).IsRequired();
            modelBuilder.Entity<Teachers>().ToTable(t => t.HasCheckConstraint("Salary", "Salary > 0"));


            modelBuilder.Entity<Curators>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Curators>().Property(p => p.SurName).IsRequired();


            modelBuilder.Entity<Faculties>().Property(p => p.Financing).IsRequired();
            modelBuilder.Entity<Faculties>().ToTable(t => t.HasCheckConstraint("Financing", "Financing >= 0"));
            modelBuilder.Entity<Faculties>().Property(p => p.Financing).HasDefaultValue(0);


            modelBuilder.Entity<Departments>().Property(p => p.Financing).IsRequired();
            modelBuilder.Entity<Departments>().ToTable(t => t.HasCheckConstraint("Financing", "Financing >= 0"));
            modelBuilder.Entity<Departments>().Property(p => p.Financing).HasDefaultValue(0);
            modelBuilder.Entity<Departments>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Departments>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Departments>().Property(p => p.FacultyId).IsRequired();


            modelBuilder.Entity<Groups>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Groups>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Groups>().Property(p => p.Course).IsRequired();
            modelBuilder.Entity<Groups>().ToTable(t => t.HasCheckConstraint("Course", "Course >= 1 AND Course <= 5"));
            modelBuilder.Entity<Groups>().Property(p => p.DepartmentId).IsRequired();


            modelBuilder.Entity<GroupsLectures>().Property(p => p.GroupId).IsRequired();
            modelBuilder.Entity<GroupsLectures>().Property(p => p.LectureId).IsRequired();


            modelBuilder.Entity<Lectures>().Property(p => p.SubjectId).IsRequired();
            modelBuilder.Entity<Lectures>().Property(p => p.TeacherId).IsRequired();


            modelBuilder.Entity<GroupsCurators>().Property(p => p.CuratorId).IsRequired();
            modelBuilder.Entity<GroupsCurators>().Property(p => p.GroupId).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public AcademicContext() : base(_options) {}
    }
}