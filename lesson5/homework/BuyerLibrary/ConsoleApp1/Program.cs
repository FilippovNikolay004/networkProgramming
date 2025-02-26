using PromoMailingDBLibrary;
using MyApp.Models;

try {
    using (var db = new PromoMailingDB()) {
        Console.WriteLine($"Подключение к базе данных успешно!");

        // Проверяем, заполнены ли таблицы
        if (!db.Buyers.Any() && !db.CountriesStocks.Any() && !db.DiscountedItems.Any() && !db.ListSections.Any()) {
            //Заполнение таблицы CountriesStocks
            var countryStocks = new List<CountryStocks>
            {
            new CountryStocks { NameCountry = "Казахстан", Discount = 25 },
            new CountryStocks { NameCountry = "Германия", Discount = 50 },
            new CountryStocks { NameCountry = "США", Discount = 15 },
            new CountryStocks { NameCountry = "Япония", Discount = 60 },
            new CountryStocks { NameCountry = "Испания", Discount = 5 }
        };
            db.CountriesStocks.AddRange(countryStocks);
            db.SaveChanges();


            // Заполнение таблицы ListSections
            var sections = new List<ListSections>
            {
            new ListSections { MobilePhone = "iPhone 15", Laptop = "MacBook Air M2", KitchenAppliances = "Микроволновка Samsung MG23", Tablets = "iPad Pro 11", TVs = "LG OLED C1" },
            new ListSections { MobilePhone = "Samsung Galaxy S23", Laptop = "Dell XPS 15", KitchenAppliances = "Блендер Philips HR2228", Tablets = "Samsung Galaxy Tab S8", TVs = "Samsung QN90A" },
            new ListSections { MobilePhone = "Google Pixel 7", Laptop = "ASUS ROG Zephyrus G14", KitchenAppliances = "Холодильник LG GA-B509", Tablets = "Xiaomi Pad 5", TVs = "Sony Bravia XR A80J" },
            new ListSections { MobilePhone = "OnePlus 11", Laptop = "Lenovo Legion 5", KitchenAppliances = "Кофемашина De'Longhi Magnifica", Tablets = "Huawei MatePad 11", TVs = "Philips Ambilight 8507" },
            new ListSections { MobilePhone = "Xiaomi 13 Pro", Laptop = "HP Spectre x360", KitchenAppliances = "Электрочайник Bosch TWK3P420", Tablets = "Lenovo Tab P12 Pro", TVs = "TCL C835" }
        };
            db.ListSections.AddRange(sections);
            db.SaveChanges();

            //Загружаем все существующие данные
            var savedSections = db.ListSections.ToList();
            var savedCountries = db.CountriesStocks.ToList(); // Исправил название

            var discountedItems = new List<DiscountedItems>
            {
            new DiscountedItems { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(1), ListSections = savedSections[0], CountryStocks = savedCountries[0] },
            new DiscountedItems { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(2), ListSections = savedSections[1], CountryStocks = savedCountries[1] },
            new DiscountedItems { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(3), ListSections = savedSections[2], CountryStocks = savedCountries[2] },
            new DiscountedItems { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(1), ListSections = savedSections[3], CountryStocks = savedCountries[3] },
            new DiscountedItems { StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddMonths(2), ListSections = savedSections[4], CountryStocks = savedCountries[4] }
        };

            db.DiscountedItems.AddRange(discountedItems);
            db.SaveChanges();

            // Заполнение таблицы Buyers
            var buyers = new List<Buyer>
            {
            new Buyer { FirstName = "Анна", LastName = "Ковальчук", DateOfBirth = new DateTime(1993, 4, 10), Gender = "Ж", Email = "anna.koval@example.com", Country = "Казахстан", City = "Алматы", ListSections = savedSections[0] },
            new Buyer { FirstName = "Михаэль", LastName = "Шнайдер", DateOfBirth = new DateTime(1988, 11, 25), Gender = "М", Email = "michael.schneider@example.com", Country = "Германия", City = "Берлин", ListSections = savedSections[2] },
            new Buyer { FirstName = "Элизабет", LastName = "Джонсон", DateOfBirth = new DateTime(1995, 7, 5), Gender = "Ж", Email = "elizabeth.johnson@example.com", Country = "США", City = "Нью-Йорк", ListSections = savedSections[1] },
            new Buyer { FirstName = "Такаши", LastName = "Сузуки", DateOfBirth = new DateTime(1990, 3, 17), Gender = "М", Email = "takashi.suzuki@example.com", Country = "Япония", City = "Токио", ListSections = savedSections[3] },
            new Buyer { FirstName = "Луис", LastName = "Гарсия", DateOfBirth = new DateTime(1985, 9, 30), Gender = "М", Email = "luis.garcia@example.com", Country = "Испания", City = "Мадрид", ListSections = savedSections[4] }
        };
            db.Buyers.AddRange(buyers);
            db.SaveChanges();

            Console.WriteLine($"Таблица заполнена!\n");
        }


        Console.WriteLine($"\nОтображение всех покупателей:");
        var buyersRequest = db.Buyers.Select(b => new { b.FirstName, b.LastName }).ToList();
        foreach (var buyer in buyersRequest) {
            Console.WriteLine($"{buyer.FirstName} {buyer.LastName}");
        }

        Console.WriteLine($"\nОтображение email всех покупателей:");
        var emails = db.Buyers.Select(b => b.Email).ToList();
        foreach (var email in emails) {
            Console.WriteLine(email);
        }

        Console.WriteLine($"\nОтображение списка разделов:");
        var sectionsRequest = db.ListSections.ToList();
        foreach (var section in sectionsRequest) {
            Console.WriteLine($"{section.MobilePhone}, {section.Laptop}, {section.KitchenAppliances}, {section.Tablets}, {section.TVs}");
        }

        Console.WriteLine($"\nОтображение списка акционных товаров:");
        var discountedItemsRequest = db.DiscountedItems.Select(d => new {
            Section = d.ListSections,
            Country = d.CountryStocks.NameCountry,
            d.StartDate,
            d.EndDate
        }).ToList();
        foreach (var item in discountedItemsRequest) {
            Console.WriteLine($"Страна: {item.Country}, Раздел: {item.Section.MobilePhone}, Начало: {item.StartDate}, Окончание: {item.EndDate}");
        }

        Console.WriteLine($"\nОтображение всех городов:");
        var cities = db.Buyers.Select(b => b.City).Distinct().ToList();
        foreach (var city in cities) {
            Console.WriteLine(city);
        }

        Console.WriteLine($"\nОтображение всех стран:");
        var countries = db.Buyers.Select(b => b.Country).Distinct().ToList();
        foreach (var country in countries) {
            Console.WriteLine(country);
        }



        string targetCity = "Токио";
        string targetCountry = "Япония";

        Console.WriteLine($"\nОтображение всех покупателей из конкретного города:");
        var buyersFromCity = db.Buyers.Where(b => b.City == targetCity)
                                      .Select(b => new { b.FirstName, b.LastName, b.Email })
                                      .ToList();
        Console.WriteLine($"Покупатели из города {targetCity}:");
        foreach (var buyer in buyersFromCity) {
            Console.WriteLine($"{buyer.FirstName} {buyer.LastName}, Email: {buyer.Email}");
        }

        Console.WriteLine($"\nОтображение всех покупателей из конкретной страны:");
        var buyersFromCountry = db.Buyers.Where(b => b.Country == targetCountry)
                                         .Select(b => new { b.FirstName, b.LastName, b.Email })
                                         .ToList();
        Console.WriteLine($"Покупатели из страны {targetCountry}:");
        foreach (var buyer in buyersFromCountry) {
            Console.WriteLine($"{buyer.FirstName} {buyer.LastName}, Email: {buyer.Email}");
        }

        Console.WriteLine($"\nОтображение всех акций для конкретной страны:");
        var discountsForCountry = db.DiscountedItems
            .Where(d => d.CountryStocks.NameCountry == targetCountry)
            .Select(d => new {
                Section = d.ListSections,
                d.StartDate,
                d.EndDate
            })
            .ToList();

        Console.WriteLine($"Акции в стране {targetCountry}:");
        foreach (var discount in discountsForCountry) {
            Console.WriteLine($"Раздел: {discount.Section.MobilePhone}, Начало: {discount.StartDate}, Окончание: {discount.EndDate}");
        }
    }
    Console.WriteLine($"\nОтключение от базы данных успешно!");
}
catch (Exception ex) {
    Console.WriteLine($"Ошибка при работе с базой данных: {ex.Message}\n");
}