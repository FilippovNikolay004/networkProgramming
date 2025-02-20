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
            while (true) {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1 - Добавить новую страну");
                Console.WriteLine("2 - Обновить данные страны");
                Console.WriteLine("3 - Удалить данные о стране");
                Console.WriteLine("4 - Показать все страны");
                Console.WriteLine("0 - Выход");
                Console.Write("Введите номер действия: ");
                string choice = Console.ReadLine();

                if (choice == "1") {
                    AddCountry(db);
                } else if (choice == "2") {
                    UpdateCountry(db);
                } else if (choice == "3") {
                    DeleteCountry(db);
                } else if (choice == "4") {
                    DisplayCountries(db);
                } else if (choice == "0") {
                    break;
                } else {
                    Console.WriteLine("Некорректный ввод, попробуйте снова.");
                }
            }
        }
    }

    static void AddCountry(ApplicationContext db) {
        Console.Write("Введите название страны: ");
        string name = Console.ReadLine();

        Console.Write("Введите столицу: ");
        string capital = Console.ReadLine();

        Console.Write("Введите население: ");
        if (!int.TryParse(Console.ReadLine(), out int population)) {
            Console.WriteLine("Ошибка: Некорректное значение населения.");
            return;
        }

        Console.Write("Введите площадь (км²): ");
        if (!double.TryParse(Console.ReadLine(), out double area)) {
            Console.WriteLine("Ошибка: Некорректное значение площади.");
            return;
        }

        Console.Write("Введите часть света (Европа, Азия, Африка и т.д.): ");
        string continent = Console.ReadLine();

        var country = new Country {
            Name = name,
            Capital = capital,
            Population = population,
            Area = area,
            Continent = continent
        };

        db.Countries.Add(country);
        db.SaveChanges();

        Console.WriteLine("Страна успешно добавлена!");
    }

    static void UpdateCountry(ApplicationContext db) {
        Console.Write("Введите ID страны, которую хотите обновить: ");
        if (!int.TryParse(Console.ReadLine(), out int countryId)) {
            Console.WriteLine("Ошибка: Некорректный ID.");
            return;
        }

        var country = db.Countries.FirstOrDefault(c => c.Id == countryId);
        if (country == null) {
            Console.WriteLine("Страна с таким ID не найдена.");
            return;
        }

        Console.WriteLine($"Вы выбрали: {country.Name} (Столица: {country.Capital})");

        Console.Write("Введите новое название страны (или оставьте пустым для пропуска): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
            country.Name = newName;

        Console.Write("Введите новую столицу (или оставьте пустым для пропуска): ");
        string newCapital = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newCapital))
            country.Capital = newCapital;

        Console.Write("Введите новое население (или оставьте пустым для пропуска): ");
        string newPopulationStr = Console.ReadLine();
        if (int.TryParse(newPopulationStr, out int newPopulation))
            country.Population = newPopulation;

        Console.Write("Введите новую площадь (или оставьте пустым для пропуска): ");
        string newAreaStr = Console.ReadLine();
        if (double.TryParse(newAreaStr, out double newArea))
            country.Area = newArea;

        Console.Write("Введите новую часть света (или оставьте пустым для пропуска): ");
        string newContinent = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newContinent))
            country.Continent = newContinent;

        db.SaveChanges();
        Console.WriteLine("Данные о стране успешно обновлены!");
    }

    static void DeleteCountry(ApplicationContext db) {
        Console.Write("Введите ID страны, которую хотите удалить: ");
        if (!int.TryParse(Console.ReadLine(), out int countryId)) {
            Console.WriteLine("Ошибка: Некорректный ID.");
            return;
        }

        var country = db.Countries.FirstOrDefault(c => c.Id == countryId);
        if (country == null) {
            Console.WriteLine("Страна с таким ID не найдена.");
            return;
        }

        db.Countries.Remove(country);
        db.SaveChanges();
        Console.WriteLine("Страна успешно удалена!");
    }


    static void DisplayCountries(ApplicationContext db) {
        var countries = db.Countries.ToList();

        if (countries.Count == 0) {
            Console.WriteLine("В базе данных нет стран.");
            return;
        }

        Console.WriteLine("\nСписок стран:");
        foreach (var country in countries) {
            Console.WriteLine($"Id: {country.Id}, Страна: {country.Name}, Столица: {country.Capital}, " +
                              $"Население: {country.Population}, Площадь: {country.Area} км^2, " +
                              $"Часть света: {country.Continent}");
        }
    }
}
