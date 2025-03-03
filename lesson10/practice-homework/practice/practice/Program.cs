using AcademyDBLibrary;

try {
    using (AcademyDBContext db = new AcademyDBContext()) {
        Console.WriteLine("БД успешно создано!");
    }
} catch (Exception ex) {
    Console.WriteLine($"Ошибка работы с БД: {ex.Message}\n{ex.InnerException?.Message}");
}