using CountryLibrary;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary {
    public class ApplicationContext : DbContext {
        public DbSet<Country> Countries { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=LAPTOP-31VSBGAE;Database=CountriesDB;Integrated Security=SSPI;TrustServerCertificate=true");
        }
    }
}
