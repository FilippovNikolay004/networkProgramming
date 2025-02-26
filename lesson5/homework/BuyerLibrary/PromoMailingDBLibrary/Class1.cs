using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using MyApp.Models;

//using BuyerLibrary;
//using CountryStocksLibrary;
//using DiscountedItemsLibrary;
//using ListSectionsLibrary;

namespace PromoMailingDBLibrary {
    public class PromoMailingDB :DbContext {
        static DbContextOptions<PromoMailingDB> _options;
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<CountryStocks> CountriesStocks { get; set; }
        public DbSet<DiscountedItems> DiscountedItems { get; set; }
        public DbSet<ListSections> ListSections { get; set; }

        static PromoMailingDB() {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath("D:\\Step\\3 course\\networkProgramming\\lesson5\\homework\\BuyerLibrary\\ConsoleApp1\\");
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<PromoMailingDB>();
            _options = optionsBuilder.UseSqlServer(connectionString).Options;
        }
        public PromoMailingDB() : base(_options) {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // метод UseLazyLoadingProxies() делает доступной ленивую загрузку.
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
