using BuyerLibrary;
using ListSectionsLibrary;
using PromoMailingDBLibrary;

using (var db = new PromoMailingDB()) {
    // Если данные уже есть, не заполняем повторно
    if (db.Buyers.Any() && db.CountriesStocks.Any() && db.DiscountedItems.Any() && db.ListSections.Any()) {
        return;
    }

    var sections = new List<ListSections> {
        new ListSections {
            MobilePhone = "iPhone 15",
            Laptop = "MacBook Air M2",
            KitchenAppliances = "Микроволновка Samsung MG23",
            Tablets = "iPad Pro 11",
            TVs = "LG OLED C1"
        },
        new ListSections {
            MobilePhone = "Samsung Galaxy S23",
            Laptop = "Dell XPS 15",
            KitchenAppliances = "Блендер Philips HR2228",
            Tablets = "Samsung Galaxy Tab S8",
            TVs = "Samsung QN90A"
        },
        new ListSections {
            MobilePhone = "Google Pixel 7",
            Laptop = "ASUS ROG Zephyrus G14",
            KitchenAppliances = "Холодильник LG GA-B509",
            Tablets = "Xiaomi Pad 5",
            TVs = "Sony Bravia XR A80J"
        },
        new ListSections {
            MobilePhone = "OnePlus 11",
            Laptop = "Lenovo Legion 5",
            KitchenAppliances = "Кофемашина De'Longhi Magnifica",
            Tablets = "Huawei MatePad 11",
            TVs = "Philips Ambilight 8507"
        },
        new ListSections {
            MobilePhone = "Xiaomi 13 Pro",
            Laptop = "HP Spectre x360",
            KitchenAppliances = "Электрочайник Bosch TWK3P420",
            Tablets = "Lenovo Tab P12 Pro",
            TVs = "TCL C835"
        }
    };
    db.ListSections.AddRange(sections);
    db.SaveChanges();


    // Загружаем все существующие разделы
    sections = db.ListSections.ToList(); 

    var buyers = new List<Buyer> {
            new Buyer {
                FirstName = "Анна",
                LastName = "Ковальчук",
                DateOfBirth = new DateTime(1993, 4, 10),
                Gender = "Ж",
                Email = "anna.koval@example.com",
                Country = "Казахстан",
                City = "Алматы",
                IdListSections = new List<ListSections> { sections[0], sections[1] } 
            },
            new Buyer {
                FirstName = "Михаэль",
                LastName = "Шнайдер",
                DateOfBirth = new DateTime(1988, 11, 25),
                Gender = "М",
                Email = "michael.schneider@example.com",
                Country = "Германия",
                City = "Берлин",
                IdListSections = new List<ListSections> { sections[2] } 
            },
            new Buyer {
                FirstName = "Элизабет",
                LastName = "Джонсон",
                DateOfBirth = new DateTime(1995, 7, 5),
                Gender = "Ж",
                Email = "elizabeth.johnson@example.com",
                Country = "США",
                City = "Нью-Йорк",
                IdListSections = new List<ListSections> { sections[1] } 
            },
            new Buyer {
                FirstName = "Такаши",
                LastName = "Сузуки",
                DateOfBirth = new DateTime(1990, 3, 17),
                Gender = "М",
                Email = "takashi.suzuki@example.com",
                Country = "Япония",
                City = "Токио",
                IdListSections = new List<ListSections> { sections[0], sections[2] } 
            },
            new Buyer {
                FirstName = "Луис",
                LastName = "Гарсия",
                DateOfBirth = new DateTime(1985, 9, 30),
                Gender = "М",
                Email = "luis.garcia@example.com",
                Country = "Испания",
                City = "Мадрид",
                IdListSections = new List<ListSections> { sections[2] } 
            }
        };

    db.Buyers.AddRange(buyers);
    db.SaveChanges();
}