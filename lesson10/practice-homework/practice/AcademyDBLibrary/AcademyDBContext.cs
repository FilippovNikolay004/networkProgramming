using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AcademyDBLibrary {
    public class AcademyDBContext : DbContext {
        DbSet<Teachers> Teachers { get; set; }
        DbSet<Subjects> Subjects { get; set; }
        DbSet<LectureRooms> LectureRooms { get; set; }
        DbSet<Assistants> Assistants { get; set; }
        DbSet<Curators> Curators { get; set; }
        DbSet<Deans> Deans { get; set; }
        DbSet<Heads> Heads { get; set; }
        DbSet<Lectures> Lectures { get; set; }
        DbSet<Schedules> Schedules { get; set; }
        DbSet<Faculties> Faculties { get; set; }
        DbSet<Departments> Departments { get; set; }
        DbSet<Groups> Groups { get; set; }
        DbSet<GroupsLectures> GroupsLectures { get; set; }
        DbSet<GroupsCurators> GroupsCurators { get; set; }

        static DbContextOptions<AcademyDBContext> _options;

        static AcademyDBContext() {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AcademyDBContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Departments -> Heads
            modelBuilder.Entity<Departments>()
                .HasOne(d => d.Heads)
                .WithMany(h => h.Departments)
                .HasForeignKey("HeadId")
                .OnDelete(DeleteBehavior.NoAction);

            // GroupsCurators -> Groups
            modelBuilder.Entity<GroupsCurators>()
                .HasOne(gc => gc.Groups)
                .WithMany(g => g.GroupsCurators)
                .HasForeignKey("GroupId")
                .OnDelete(DeleteBehavior.NoAction);

            // GroupsLectures -> Groups
            modelBuilder.Entity<GroupsLectures>()
                .HasOne(gl => gl.Groups)
                .WithMany(g => g.GroupsLectures)
                .HasForeignKey("GroupId")
                .OnDelete(DeleteBehavior.NoAction);


            // Teachers
            modelBuilder.Entity<Teachers>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Teachers>().Property(p => p.Name).HasColumnType("nvarchar");
            modelBuilder.Entity<Teachers>().Property(p => p.SurName).IsRequired();
            modelBuilder.Entity<Teachers>().Property(p => p.SurName).HasColumnType("nvarchar");

            // Subjects
            modelBuilder.Entity<Subjects>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Subjects>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Subjects>().Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100);

            // LectureRooms
            modelBuilder.Entity<LectureRooms>().Property(p => p.Building).IsRequired();
            modelBuilder.Entity<LectureRooms>().ToTable(t => t.HasCheckConstraint("Building", "Building >= 1 AND Building <= 5"));
            modelBuilder.Entity<LectureRooms>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<LectureRooms>().Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(10);
            modelBuilder.Entity<LectureRooms>().HasIndex(p => p.Name).IsUnique();

            // Assistants
            //modelBuilder.Entity<Assistants>().Property(p => p.Teachers).IsRequired();
            modelBuilder.Entity<Assistants>()
                .HasOne(a => a.Teachers)
                .WithMany(t => t.Assistants)
                .HasForeignKey("TeacherId").IsRequired();

            // Curators
            //modelBuilder.Entity<Curators>().Property(p => p.Teachers).IsRequired();
            modelBuilder.Entity<Curators>()
                .HasOne(c => c.Teachers)
                .WithMany(t => t.Curators) 
                .HasForeignKey("TeacherId").IsRequired();

            // Deans
            //modelBuilder.Entity<Deans>().Property(p => p.Teachers).IsRequired();
            modelBuilder.Entity<Deans>()
                .HasOne(c => c.Teachers)
                .WithMany(t => t.Deans)
                .HasForeignKey("TeacherId").IsRequired();

            // Heads
            //modelBuilder.Entity<Heads>().Property(p => p.Teachers).IsRequired();
            modelBuilder.Entity<Heads>()
                .HasOne(c => c.Teachers)
                .WithMany(t => t.Heads)
                .HasForeignKey("TeacherId").IsRequired();

            // Lectures
            //modelBuilder.Entity<Lectures>().Property(p => p.Subjects).IsRequired();
            modelBuilder.Entity<Lectures>()
                .HasOne(c => c.Subjects)
                .WithMany(t => t.Lectures)
                .HasForeignKey("SubjectId").IsRequired();
            //modelBuilder.Entity<Lectures>().Property(p => p.Teachers).IsRequired();
            modelBuilder.Entity<Lectures>()
                .HasOne(c => c.Teachers)
                .WithMany(t => t.Lectures)
                .HasForeignKey("SubjectId").IsRequired();

            // Schedules
            modelBuilder.Entity<Schedules>().Property(p => p.Class).IsRequired();
            modelBuilder.Entity<Schedules>().ToTable(t => t.HasCheckConstraint("Class", "Class >= 1 AND Class <= 8"));
            modelBuilder.Entity<Schedules>().Property(p => p.DayOfWeek).IsRequired();
            modelBuilder.Entity<Schedules>().ToTable(t => t.HasCheckConstraint("DayOfWeek", "DayOfWeek >= 1 AND DayOfWeek <= 7"));
            modelBuilder.Entity<Schedules>().Property(p => p.Week).IsRequired();
            modelBuilder.Entity<Schedules>().ToTable(t => t.HasCheckConstraint("Week", "Week >= 1 AND DayOfWeek <= 52"));
            //modelBuilder.Entity<Schedules>().Property(p => p.Lectures).IsRequired();
            modelBuilder.Entity<Schedules>()
                .HasOne(c => c.Lectures)
                .WithMany(t => t.Schedules)
                .HasForeignKey("LectureId").IsRequired();
            //modelBuilder.Entity<Schedules>().Property(p => p.LectureRooms).IsRequired();
            modelBuilder.Entity<Schedules>()
                .HasOne(c => c.LectureRooms)
                .WithMany(t => t.Schedules)
                .HasForeignKey("LectureRoomId").IsRequired();

            // Faculties
            modelBuilder.Entity<Faculties>().Property(p => p.Building).IsRequired();
            modelBuilder.Entity<Faculties>().ToTable(t => t.HasCheckConstraint("Building", "Building >= 1 AND Building <= 5"));
            modelBuilder.Entity<Faculties>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Faculties>().Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100);
            modelBuilder.Entity<Faculties>().HasIndex(p => p.Name).IsUnique();
            //modelBuilder.Entity<Faculties>().Property(p => p.Deans).IsRequired();
            modelBuilder.Entity<Faculties>()
                .HasOne(c => c.Deans)
                .WithMany(t => t.Faculties)
                .HasForeignKey("DeanId").IsRequired();

            // Departments
            modelBuilder.Entity<Departments>().Property(p => p.Building).IsRequired();
            modelBuilder.Entity<Departments>().ToTable(t => t.HasCheckConstraint("Building", "Building >= 1 AND Building <= 5"));
            modelBuilder.Entity<Departments>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Departments>().Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100);
            modelBuilder.Entity<Departments>().HasIndex(p => p.Name).IsUnique();
            //modelBuilder.Entity<Departments>().Property(p => p.Faculties).IsRequired();
            modelBuilder.Entity<Departments>()
                .HasOne(c => c.Faculties)
                .WithMany(t => t.Departments)
                .HasForeignKey("FacultyId").IsRequired();
            //modelBuilder.Entity<Departments>().Property(p => p.Heads).IsRequired();
            modelBuilder.Entity<Departments>()
                .HasOne(c => c.Heads)
                .WithMany(t => t.Departments)
                .HasForeignKey("HeadId").IsRequired();

            // Groups
            modelBuilder.Entity<Groups>().Property(p => p.Name).IsRequired();
            modelBuilder.Entity<Groups>().Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(10);
            modelBuilder.Entity<Groups>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Groups>().Property(p => p.Year).IsRequired();
            modelBuilder.Entity<Groups>().ToTable(t => t.HasCheckConstraint("Year", "Year >= 1 AND Year <= 5"));
            //modelBuilder.Entity<Groups>().Property(p => p.Departments).IsRequired();
            modelBuilder.Entity<Groups>()
                .HasOne(c => c.Departments)
                .WithMany(t => t.Groups)
                .HasForeignKey("DepartmentId").IsRequired();

            // GroupsLectures
            //modelBuilder.Entity<GroupsLectures>().Property(p => p.Groups).IsRequired();
            modelBuilder.Entity<GroupsLectures>()
                .HasOne(c => c.Groups)
                .WithMany(t => t.GroupsLectures)
                .HasForeignKey("GroupId").IsRequired();
            //modelBuilder.Entity<GroupsLectures>().Property(p => p.Lectures).IsRequired();
            modelBuilder.Entity<GroupsLectures>()
                .HasOne(c => c.Lectures)
                .WithMany(t => t.GroupsLectures)
                .HasForeignKey("LectureId").IsRequired();

            // GroupsCurators
            //modelBuilder.Entity<GroupsCurators>().Property(p => p.Curators).IsRequired();
            modelBuilder.Entity<GroupsCurators>()
                .HasOne(c => c.Curators)
                .WithMany(t => t.GroupsCurators)
                .HasForeignKey("CuratorId").IsRequired();
            //modelBuilder.Entity<GroupsCurators>().Property(p => p.Groups).IsRequired();
            modelBuilder.Entity<GroupsCurators>()
                .HasOne(c => c.Groups)
                .WithMany(t => t.GroupsCurators)
                .HasForeignKey("GroupId").IsRequired();


            base.OnModelCreating(modelBuilder);
        }

        public AcademyDBContext() : base(_options) { 
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
