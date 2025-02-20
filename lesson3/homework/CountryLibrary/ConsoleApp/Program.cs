using System;
using System.Linq;
using DatabaseLibrary;
using CountryLibrary;
using Microsoft.EntityFrameworkCore;

class Program {
    static void Main() {
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseSqlServer(@"Server=LAPTOP-31VSBGAE;Database=CountriesDB;Integrated Security=SSPI;TrustServerCertificate=true")
            .Options;

        using (var db = new ApplicationContext(options)) {
            db.Database.EnsureCreated();

            if (!db.Countries.Any())
            {
                db.Countries.AddRange(
                    new Country { Name = "Казахстан", Capital = "Астана", Population = 19000000, Area = 2724900, Continent = "Азия" },
                    new Country { Name = "Испания", Capital = "Мадрид", Population = 47000000, Area = 505992, Continent = "Европа" },
                    new Country { Name = "Канада", Capital = "Оттава", Population = 38000000, Area = 9984670, Continent = "Северная Америка" },
                    new Country { Name = "США", Capital = "Вашингтон", Population = 331000000, Area = 9833517, Continent = "Северная Америка" },
                    new Country { Name = "Китай", Capital = "Пекин", Population = 1402000000, Area = 9596961, Continent = "Азия" },
                    new Country { Name = "Япония", Capital = "Токио", Population = 125000000, Area = 377975, Continent = "Азия" }
                );
                db.SaveChanges();
            }

            Console.WriteLine("Список стран:");
            foreach (var country in db.Countries.ToList()) {
                Console.WriteLine($"{country.Name} - {country.Capital}, {country.Population} чел., {country.Area} км^2, {country.Continent}");
            }
        }
    }
}
