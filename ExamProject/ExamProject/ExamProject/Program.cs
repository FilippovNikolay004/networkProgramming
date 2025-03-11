using BookstoreDBLibrary;
using accountManager;
using ExamProject;
using System.Runtime.Intrinsics.Arm;
using System.Net;
using System.Collections.Generic;

try {
    Console.WriteLine("Попытка подключения к базе данных...");

    using (BookstoreDBContext db = new BookstoreDBContext()) {
        Console.WriteLine("Подключение к базе данных успешно установлено.");
        InitializationDataBase();
        bool isNext = false;
        do {
            Console.WriteLine("\tДобро пожаловать в");
            Console.WriteLine("\t/* === BookStore === */");
            Console.WriteLine("Выполните вход или зарегистрируйтесь");
            Console.WriteLine("1. Вход");
            Console.WriteLine("2. Регистрация");
            Console.Write("Ввод: ");

            string choice = Console.ReadLine();

            switch (choice) {
            case "1":
                isNext = Authorization(db);
                break;
            case "2":
                try {
                    db.Users.Add(Registrations());
                    db.SaveChanges();
                    isNext = true;
                    Console.WriteLine("Новый пользователь успешно зарегистрирован.");
                    Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
                    Console.ReadKey();
                }
                catch (Exception ex) {
                    Console.WriteLine($"Ошибка при регистрации пользователя: {ex.Message}");
                }
                break;
            default:
                Console.WriteLine("Некорректный ввод! Попробуйте снова.");
                break;
            }
        } while (!isNext);

        while (true) {
            Thread.Sleep(1000);
            Console.Clear();

            Menu();

            //Console.Write("Ввод: ");
            string choice = Console.ReadLine();

            if (choice == "0") {
                break;
            }

            switch (choice) {
            case "1":
                AddBook();
                break;
            case "2":
                RemoveBook();
                break;
            case "3":
                EditBook();
                break;
            case "4":
                SellBook();
                break;
            case "5":
                WriteOffBook();
                break;
            case "6":
                AddBookToPromotion();
                break;
            case "7":
                ReserveBook();
                break;
            case "8":
                SearchBooks();
                break;
            case "9":
                ViewStatistics();
                break;
            default:
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                break;
            }
        }
    }

    Thread.Sleep(500);
    Console.Clear();
    Console.WriteLine("Соединение с базой данных закрыто.");
}
catch (Exception ex) {
    Console.WriteLine($"Ошибка работы с БД: {ex.Message}\n{ex.InnerException?.Message}");
}


Users Registrations() {
    string login = AccountManager.CorrectEnter("Создайте логин", "Вы ввели недопустимое значение!");
    string password = AccountManager.CorrectEnter("Создайте пароль", "Вы ввели недопустимое значение!", true);
    string email = AccountManager.CorrectEnter("Введите почту", "Вы ввели недопустимое значение!");

    return new Users { Login = login, Password = password, Email = email };
}
bool Authorization(BookstoreDBContext db) {
    try {
        string login = AccountManager.CorrectEnter("Введите логин", "Вы ввели недопустимое значение!");
        string password = AccountManager.CorrectEnter("Введите пароль", "Вы ввели недопустимое значение!", true);

        var user = db.Users.FirstOrDefault(u => u.Login == login);

        if (user == null) {
            Console.WriteLine("Пользователь не найден.");
            return false;
        }

        if (password == user.Password) {
            Console.WriteLine("Авторизация прошла успешна!");
            return true;
        }

        Console.WriteLine("Неверный логин или пароль.");
        return false;
    }
    catch (Exception ex) {
        Console.WriteLine($"Ошибка при авторизации: {ex.Message}");
        return false;
    }
}


static void AddBook() {
    // Реализация добавления книги
    string msgError = "Вы ввели недопустимое значение!";
    bool isNext = false;

    string bookTitle = AccountManager.CorrectEnter("Введите название книги", msgError);
    string publisherName = AccountManager.CorrectEnter("Введите имя издателя", msgError);
    int numberOfPages = int.Parse(AccountManager.CorrectEnter("Введите количество страниц", msgError));
    string genre = AccountManager.CorrectEnter("Введите жанр книги", msgError);
    int publicationYear = AccountManager.CorrectEnterDate("Введите дату выпуска", msgError, 2025);
    double productionCost = double.Parse(AccountManager.CorrectEnter("Введите стоимость производства", msgError));
    double sellingPrice = double.Parse(AccountManager.CorrectEnter("Введите цену на продажу", msgError));
    bool isSequel = false;

    do {
        Console.Write("Это сиквел?\n1 - Да\n2 - Нет\nВвод: ");
        string userChoice = Console.ReadLine();
        if (userChoice == "1") {
            isSequel = true;
            isNext = true;
        } else if (userChoice != "1" && userChoice != "2") {
            Console.WriteLine(msgError);
        } else { isNext = true; }
    } while (!isNext);

    using (BookstoreDBContext db = new BookstoreDBContext()) {
        db.Books.Add(new Books {
            BookTitle = bookTitle,
            PublisherName = publisherName,
            NumberOfPages = numberOfPages,
            Genre = genre,
            PublicationYear = publicationYear,
            ProductionCost = productionCost,
            SellingPrice = sellingPrice,
            IsSequel = isSequel
        });
        db.SaveChanges();
    }
}
static void RemoveBook() {
    // Реализация удаления книги
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги или введите -1 для выхода", msgError));

        if (bookId == -1) {
            return;
        }

        var bookToRemove = db.Books.Find(bookId);
        if (bookToRemove != null) {
            db.Books.Remove(bookToRemove);
            db.SaveChanges();
            Console.WriteLine($"Книга с ID: {bookId} удалена.");
            return;
        }

        Console.WriteLine($"Книга с ID: {bookId} не найдена.");
    }
}
static void EditBook() {
    // Реализация редактирования книги
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги для редактирования или введите -1 для выхода", msgError));

        if (bookId == -1) {
            return;
        }

        var bookToEdit = db.Books.Find(bookId);
        if (bookToEdit != null) {
            // Запрос новых значений
            Console.Write("Новое название: ");
            bookToEdit.BookTitle = Console.ReadLine();

            Console.Write("Новый издатель: ");
            bookToEdit.PublisherName = Console.ReadLine();

            Console.Write("Новое количество страниц: ");
            if (int.TryParse(Console.ReadLine(), out int pages)) {
                bookToEdit.NumberOfPages = pages;
            }

            Console.Write("Новый жанр: ");
            bookToEdit.Genre = Console.ReadLine();

            Console.Write("Новый год публикации: ");
            if (int.TryParse(Console.ReadLine(), out int year)) {
                bookToEdit.PublicationYear = year;
            }

            Console.Write("Новая себестоимость: ");
            if (double.TryParse(Console.ReadLine(), out double cost)) {
                bookToEdit.ProductionCost = cost;
            }

            Console.Write("Новая цена продажи: ");
            if (double.TryParse(Console.ReadLine(), out double price)) {
                bookToEdit.SellingPrice = price;
            }

            Console.Write("Является ли продолжением (true/false): ");
            if (bool.TryParse(Console.ReadLine(), out bool sequel)) {
                bookToEdit.IsSequel = sequel;
            }

            db.SaveChanges();
            Console.WriteLine("Книга отредактирована.");
        } else {
            Console.WriteLine($"Книга с ID {bookId} не найдена.");
        }
    }
}
static void SellBook() {
    // Реализация продажи книги
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг для выбора
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}, Цена: {book.SellingPrice}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги для продажи или введите -1 для выхода", msgError));
        if (bookId == -1) {
            return;
        }
        var bookToSell = db.Books.Find(bookId);

        // Вывод пользователей для выбора
        Console.WriteLine("Список пользователей:");
        foreach (var usr in db.Users) {
            Console.WriteLine($"ID: {usr.Id}, Логин: {usr.Login}");
        }
        int userId = int.Parse(AccountManager.CorrectEnter("Введите ID пользователя или введите -1 для выхода", msgError));
        if (userId == -1) {
            return;
        }
        var user = db.Users.Find(userId);

        // Проверка наличия книги на складе
        var bookStock = db.BookStocks.FirstOrDefault(bs => bs.Book.Id == bookId);
        if (bookStock == null && bookStock.Quantity == 0) {
            Console.WriteLine("Книги нет в наличии.");
            return;
        }

        bool isPromotion = false;
        bool isNext = false;
        do {
            Console.Write("Является ли продажа акционной?\n1 - Да\n2 - Нет\nВвод: ");
            string userChoice = Console.ReadLine();
            if (userChoice == "1") {
                isPromotion = true;
                isNext = true;
            } else if (userChoice != "1" && userChoice != "2") {
                Console.WriteLine(msgError);
            } else { isNext = true; }
        } while (!isNext);

        // Создание записи в SalesReports
        db.SalesReports.Add(new SalesReports {
            User = user,
            Book = bookToSell,
            SalePrice = bookToSell.SellingPrice,
            SaleDate = DateTime.Now,
            IsPromotion = isPromotion
        });

        // Уменьшение количества книг на складе
        bookStock.Quantity--;

        db.SaveChanges();
        Console.WriteLine("Книга продана.");
    }
}
static void WriteOffBook() {
    // Реализация списания книги
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг для выбора
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги для списания или введите -1 для выхода", msgError));
        if (bookId == -1) {
            return;
        }
        var bookToOff = db.Books.Find(bookId);

        // Проверка наличия книги на складе
        var bookStock = db.BookStocks.FirstOrDefault(bs => bs.Book.Id == bookId);
        if (bookStock == null || bookStock.Quantity == 0) {
            Console.WriteLine("Книги нет в наличии.");
            return;
        }

        int quantity = int.Parse(AccountManager.CorrectEnter($"Введите количество книг для списания (максимум {bookStock.Quantity})", msgError));
        if (quantity > bookStock.Quantity) {
            Console.WriteLine($"Введено слишком большое количество. Максимально допустимое: {bookStock.Quantity}");
            return;
        }

        // Уменьшение количества книг на складе
        bookStock.Quantity -= quantity;

        db.SaveChanges();
        Console.WriteLine($"Списано {quantity} книг(и).");
    }
}
static void AddBookToPromotion() {
    // Реализация добавления книги в акцию
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг для выбора
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги для добавления в акцию или введите -1 для выхода", msgError));
        if (bookId == -1) {
            return;
        }
        var bookToPromote = db.Books.Find(bookId);

        // Запрос темы акции
        Console.Write("Введите тему акции: ");
        string theme = Console.ReadLine();

        // Запрос скидки
        double discount = double.Parse(AccountManager.CorrectEnter("Введите скидку (например, 0.1 для 10%)", msgError));

        // Запрос даты начала акции
        DateTime startDate = DateTime.Parse(AccountManager.CorrectEnter("Введите дату начала акции (ГГГГ-ММ-ДД)", msgError));

        // Запрос даты окончания акции
        DateTime endDate = DateTime.Parse(AccountManager.CorrectEnter("Введите дату окончания акции (ГГГГ-ММ-ДД)", msgError));

        // Создание записи в BookPromotions
        db.BookPromotions.Add(new BookPromotions {
            Book = bookToPromote,
            Theme = theme,
            Discount = discount,
            StartDate = startDate,
            EndDate = endDate,
            // Предполагаем, что акция активна сразу после добавления
            IsActive = true 
        });

        db.SaveChanges();
        Console.WriteLine("Книга добавлена в акцию.");
    }
}
static void ReserveBook() {
    // Реализация откладывания книги
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // Вывод списка книг для выбора
        Console.WriteLine("Список книг:");
        foreach (var book in db.Books) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}");
        }

        string msgError = "Вы ввели недопустимое значение!";
        int bookId = int.Parse(AccountManager.CorrectEnter("Введите ID книги для откладывания или введите -1 для выхода", msgError));
        if (bookId == -1) {
            return;
        }
        var bookToReserve = db.Books.Find(bookId);

        // Вывод списка пользователей для выбора
        Console.WriteLine("Список пользователей:");
        foreach (var user in db.Users) {
            Console.WriteLine($"ID: {user.Id}, Логин: {user.Login}");
        }
        int userId = int.Parse(AccountManager.CorrectEnter("Введите ID пользователя для откладывания или введите -1 для выхода", msgError));
        if (userId == -1) {
            return;
        }
        var userReserving = db.Users.Find(userId);

        // Проверка наличия книги на складе
        var bookStock = db.BookStocks.FirstOrDefault(bs => bs.Book.Id == bookId);
        if (bookStock == null || bookStock.Quantity == 0) {
            Console.WriteLine("Книги нет в наличии.");
            return;
        }

        // Запрос даты окончания бронирования
        DateTime expirationDate = DateTime.Parse(AccountManager.CorrectEnter("Введите дату окончания бронирования (ГГГГ-ММ-ДД)", msgError));

        // Создание записи в ReservedBooks
        db.ReservedBooks.Add(new ReservedBooks {
            User = userReserving,
            Book = bookToReserve,
            ReservationDate = DateTime.Now,
            ExpirationDate = expirationDate
        });

        db.SaveChanges();
        Console.WriteLine("Книга отложена.");
    }
}
static void SearchBooks() {
    // Реализация поиска книг
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        Console.Write("Введите поисковый запрос: ");
        string searchQuery = Console.ReadLine();

        if (string.IsNullOrEmpty(searchQuery)) {
            Console.WriteLine("Поисковый запрос не может быть пустым.");
            return;
        }

        // Поиск книг по названию, автору и жанру
        var searchResults = db.Books
            .Where(b => b.BookTitle.Contains(searchQuery) ||
                        b.BookAuthors.Any(ba => ba.Author.FirstName.Contains(searchQuery) ||
                                                ba.Author.LastName.Contains(searchQuery)) ||
                        b.Genre.Contains(searchQuery)).ToList();

        if (searchResults.Count < 0) {
            Console.WriteLine("Книги не найдены.");
        } else {
            Console.WriteLine("Результаты поиска:");
            foreach (var book in searchResults) {
                Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Издатель: {book.PublisherName}, Жанр: {book.Genre}");
                // Вывод авторов книги
                var authors = db.BookAuthors
                    .Where(ba => ba.Book.Id == book.Id)
                    .Select(ba => ba.Author).ToList();
                if (authors.Count > 0) {
                    Console.Write("Авторы: ");
                    foreach (var author in authors) {
                        Console.Write($"{author.FirstName} {author.LastName}, ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }

    Console.WriteLine("Нажмите на любую клавишу чтобы продолжить");
    Console.ReadKey();
}
static void ViewStatistics() {
    // Реализация просмотра статистики
    using (BookstoreDBContext db = new BookstoreDBContext()) {
        // 1. Список новинок (опубликованных за последний год)
        Console.WriteLine("\nСписок новинок:");
        var newBooks = db.Books
            .Where(b => b.PublicationYear >= DateTime.Now.Year - 1)
            .ToList();
        foreach (var book in newBooks) {
            Console.WriteLine($"ID: {book.Id}, Название: {book.BookTitle}, Год публикации: {book.PublicationYear}");
        }

        // 2. Список самых продаваемых книг
        Console.WriteLine("\nСписок самых продаваемых книг:");
        var topSellingBooks = db.SalesReports
            .GroupBy(sr => sr.Book)
            .Select(g => new { Book = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(5) // Топ 5
            .ToList();
        foreach (var item in topSellingBooks) {
            Console.WriteLine($"Название: {item.Book.BookTitle}, Продано: {item.Count} раз");
        }

        // 3. Список самых популярных авторов
        Console.WriteLine("\nСписок самых популярных авторов:");
        var topAuthors = db.BookAuthors
            .GroupBy(ba => ba.Author)
            .Select(g => new { Author = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(5) // Топ 5
            .ToList();
        foreach (var item in topAuthors) {
            Console.WriteLine($"Автор: {item.Author.FirstName} {item.Author.LastName}, Книг продано: {item.Count}");
        }

        // 4. Список самых популярных жанров за день
        Console.WriteLine("\nСписок самых популярных жанров за день:");
        var topGenresDay = db.SalesReports
            .Where(sr => sr.SaleDate.Date == DateTime.Now.Date)
            .GroupBy(sr => sr.Book.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(3) // Топ 3
            .ToList();
        foreach (var item in topGenresDay) {
            Console.WriteLine($"Жанр: {item.Genre}, Продано: {item.Count} раз");
        }

        // 5. Список самых популярных жанров за неделю
        Console.WriteLine("\nСписок самых популярных жанров за неделю:");
        var topGenresWeek = db.SalesReports
            .Where(sr => sr.SaleDate >= DateTime.Now.AddDays(-7))
            .GroupBy(sr => sr.Book.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(3) // Топ 3
            .ToList();
        foreach (var item in topGenresWeek) {
            Console.WriteLine($"Жанр: {item.Genre}, Продано: {item.Count} раз");
        }

        // 6. Список самых популярных жанров за месяц
        Console.WriteLine("\nСписок самых популярных жанров за месяц:");
        var topGenresMonth = db.SalesReports
            .Where(sr => sr.SaleDate >= DateTime.Now.AddMonths(-1))
            .GroupBy(sr => sr.Book.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(3) // Топ 3
            .ToList();
        foreach (var item in topGenresMonth) {
            Console.WriteLine($"Жанр: {item.Genre}, Продано: {item.Count} раз");
        }

        // 7. Список самых популярных жанров за год
        Console.WriteLine("\nСписок самых популярных жанров за год:");
        var topGenresYear = db.SalesReports
            .Where(sr => sr.SaleDate >= DateTime.Now.AddYears(-1))
            .GroupBy(sr => sr.Book.Genre)
            .Select(g => new { Genre = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .Take(3) // Топ 3
            .ToList();
        foreach (var item in topGenresYear) {
            Console.WriteLine($"Жанр: {item.Genre}, Продано: {item.Count} раз");
        }
    }

    Console.WriteLine("Нажмите на любую клавишу чтобы продолжить");
    Console.ReadKey();
}

static void Menu() {
    Console.WriteLine("1. Добавить книгу");
    Console.WriteLine("2. Удалить книгу");
    Console.WriteLine("3. Редактировать параметры книги");
    Console.WriteLine("4. Продать книгу");
    Console.WriteLine("5. Списать книгу");
    Console.WriteLine("6. Добавить книгу в акцию");
    Console.WriteLine("7. Отложить книгу для покупателя");
    Console.WriteLine("8. Поиск книг");
    Console.WriteLine("9. Просмотр статистики");
    Console.WriteLine("0. Выход");
    return;
}

static void InitializationDataBase() {
    try {
        Console.WriteLine("Попытка подключения к базе данных и инициализация...");

        using (BookstoreDBContext db = new BookstoreDBContext()) {
            Console.WriteLine("Подключение к базе данных и инициализация прошла успешно.");

            // Авторы
            var author1 = new Authors { FirstName = "Анджей", LastName = "Сапковский" };
            var author2 = new Authors { FirstName = "Ребекка", LastName = "Яррос" };
            var author3 = new Authors { FirstName = "Михаил", LastName = "Булгаков" };
            var author4 = new Authors { FirstName = "Джон", LastName = "Толкин" };
            var author5 = new Authors { FirstName = "Джоан", LastName = "Роулинг" };

            db.Authors.AddRange(author1, author2, author3, author4, author5);
            db.SaveChanges();

            // Книги
            var book1 = new Books {
                BookTitle = "Ведьмак",
                PublisherName = "АСТ",
                NumberOfPages = 400,
                Genre = "Фэнтези",
                PublicationYear = 2007,
                ProductionCost = 250,
                SellingPrice = 500,
                IsSequel = false
            };
            var book2 = new Books {
                BookTitle = "Четвертое крыло",
                PublisherName = "Азбука",
                NumberOfPages = 600,
                Genre = "Фэнтези",
                PublicationYear = 2023,
                ProductionCost = 300,
                SellingPrice = 700,
                IsSequel = true
            };
            var book3 = new Books {
                BookTitle = "Мастер и Маргарита",
                PublisherName = "Эксмо",
                NumberOfPages = 500,
                Genre = "Роман",
                PublicationYear = 1967,
                ProductionCost = 200,
                SellingPrice = 450,
                IsSequel = false
            };
            var book4 = new Books {
                BookTitle = "Властелин колец",
                PublisherName = "АСТ",
                NumberOfPages = 1200,
                Genre = "Фэнтези",
                PublicationYear = 1954,
                ProductionCost = 400,
                SellingPrice = 800,
                IsSequel = false
            };
            var book5 = new Books {
                BookTitle = "Гарри Поттер и философский камень",
                PublisherName = "Росмэн",
                NumberOfPages = 300,
                Genre = "Фэнтези",
                PublicationYear = 1997,
                ProductionCost = 200,
                SellingPrice = 400,
                IsSequel = false
            };

            db.Books.AddRange(book1, book2, book3, book4, book5);
            db.SaveChanges();

            // BookAuthors
            db.BookAuthors.AddRange(
                new BookAuthors { Author = author1, Book = book1 },
                new BookAuthors { Author = author2, Book = book2 },
                new BookAuthors { Author = author3, Book = book3 },
                new BookAuthors { Author = author4, Book = book4 },
                new BookAuthors { Author = author5, Book = book5 }
            );
            db.SaveChanges();

            // BookStocks
            db.BookStocks.AddRange(
                new BookStock { Book = book1, Quantity = 100 },
                new BookStock { Book = book2, Quantity = 50 },
                new BookStock { Book = book3, Quantity = 75 },
                new BookStock { Book = book4, Quantity = 200 },
                new BookStock { Book = book5, Quantity = 150 }
            );
            db.SaveChanges();

            // Users
            var user1 = new Users { Login = "user1", Password = "password1", Email = "user1@example.com" };
            var user2 = new Users { Login = "user2", Password = "password2", Email = "user2@example.com" };
            var user3 = new Users { Login = "user3", Password = "password3", Email = "user3@example.com" };
            var user4 = new Users { Login = "user4", Password = "password4", Email = "user4@example.com" };
            var user5 = new Users { Login = "user5", Password = "password5", Email = "user5@example.com" };

            db.Users.AddRange(user1, user2, user3, user4, user5);
            db.SaveChanges();

            // ReservedBooks
            db.ReservedBooks.AddRange(
                new ReservedBooks { User = user1, Book = book1, ReservationDate = DateTime.Now.AddDays(-1), ExpirationDate = DateTime.Now.AddDays(7) },
                new ReservedBooks { User = user2, Book = book2, ReservationDate = DateTime.Now.AddDays(-2), ExpirationDate = DateTime.Now.AddDays(6) },
                new ReservedBooks { User = user3, Book = book3, ReservationDate = DateTime.Now.AddDays(-3), ExpirationDate = DateTime.Now.AddDays(5) },
                new ReservedBooks { User = user4, Book = book4, ReservationDate = DateTime.Now.AddDays(-4), ExpirationDate = DateTime.Now.AddDays(4) },
                new ReservedBooks { User = user5, Book = book5, ReservationDate = DateTime.Now.AddDays(-5), ExpirationDate = DateTime.Now.AddDays(3) }
            );
            db.SaveChanges();

            // SalesReports
            db.SalesReports.AddRange(
                new SalesReports { User = user1, Book = book1, SalePrice = 500, SaleDate = DateTime.Now.AddDays(-1), IsPromotion = false },
                new SalesReports { User = user2, Book = book2, SalePrice = 700, SaleDate = DateTime.Now.AddDays(-2), IsPromotion = true },
                new SalesReports { User = user3, Book = book3, SalePrice = 450, SaleDate = DateTime.Now.AddDays(-3), IsPromotion = false },
                new SalesReports { User = user4, Book = book4, SalePrice = 800, SaleDate = DateTime.Now.AddDays(-4), IsPromotion = true },
                new SalesReports { User = user5, Book = book5, SalePrice = 400, SaleDate = DateTime.Now.AddDays(-5), IsPromotion = false }
            );
            db.SaveChanges();

            // BookPromotions
            db.BookPromotions.AddRange(
                new BookPromotions { Book = book1, Theme = "Летняя распродажа", Discount = 0.1, StartDate = DateTime.Now.AddDays(-7), EndDate = DateTime.Now.AddDays(7), IsActive = true },
                new BookPromotions { Book = book2, Theme = "Новинка", Discount = 0.2, StartDate = DateTime.Now.AddDays(-14), EndDate = DateTime.Now.AddDays(0), IsActive = false },
                new BookPromotions { Book = book3, Theme = "Классика", Discount = 0.05, StartDate = DateTime.Now.AddDays(-30), EndDate = DateTime.Now.AddDays(30), IsActive = true },
                new BookPromotions { Book = book4, Theme = "Фэнтези недели", Discount = 0.15, StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now.AddDays(4), IsActive = true },
                new BookPromotions { Book = book5, Theme = "Детская литература", Discount = 0.1, StartDate = DateTime.Now.AddDays(-5), EndDate = DateTime.Now.AddDays(2), IsActive = false }
            );
            db.SaveChanges();
        }

        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Инициализация БД завершена!");
    } catch (Exception ex) {
        Console.WriteLine($"Ошибка работы с БД: {ex.Message}\n{ex.InnerException?.Message}");
    }
}