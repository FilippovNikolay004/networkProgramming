using ExamProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreDBLibrary {
    public class BookstoreDBContext :DbContext {
        public DbSet<Authors> Authors { get; set; }
        public DbSet<BookAuthors> BookAuthors { get; set; }
        public DbSet<BookPromotions> BookPromotions { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        public DbSet<ReservedBooks> ReservedBooks { get; set; }
        public DbSet<SalesReports> SalesReports { get; set; }
        public DbSet<Users> Users { get; set; }

        static DbContextOptions<BookstoreDBContext> _options;

        static BookstoreDBContext() {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BookstoreDBContext>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);
        }

        public BookstoreDBContext() : base(_options) {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
