using AcademicLibrary;

namespace homework {
    class Program {
        static void Main(string[] args) {
            try {
                using (AcademicContext db = new AcademicContext()) {
                    // Subjects
                    db.Subjects.AddRange(
                        new Subjects { Name = "Математика" },
                        new Subjects { Name = "Физика" },
                        new Subjects { Name = "Информатика" },
                        new Subjects { Name = "Химия" },
                        new Subjects { Name = "Биология" }
                    );
                    db.SaveChanges();

                    // Teachers
                    db.Teachers.AddRange(
                        new Teachers { Name = "Иван", SurName = "Иванов", Salary = 50000 },
                        new Teachers { Name = "Петр", SurName = "Петров", Salary = 60000 },
                        new Teachers { Name = "Елена", SurName = "Сидорова", Salary = 55000 },
                        new Teachers { Name = "Алексей", SurName = "Кузнецов", Salary = 70000 },
                        new Teachers { Name = "Ольга", SurName = "Смирнова", Salary = 65000 }
                    );
                    db.SaveChanges();

                    // Curators
                    db.Curators.AddRange(
                        new Curators { Name = "Анна", SurName = "Волкова" },
                        new Curators { Name = "Дмитрий", SurName = "Морозов" },
                        new Curators { Name = "Наталья", SurName = "Попова" }
                    );
                    db.SaveChanges();

                    // Faculties
                    db.Faculties.AddRange(
                        new Faculties { Name = "Физико-математический", Financing = 1000000 },
                        new Faculties { Name = "Информационных технологий", Financing = 1200000 },
                        new Faculties { Name = "Биологический", Financing = 900000 }
                    );
                    db.SaveChanges();

                    // Departments
                    db.Departments.AddRange(
                        new Departments { Name = "Математический анализ", Financing = 300000, FacultyId = 1 },
                        new Departments { Name = "Программирование", Financing = 400000, FacultyId = 2 },
                        new Departments { Name = "Общая биология", Financing = 250000, FacultyId = 3 },
                        new Departments { Name = "Высшая математика", Financing = 350000, FacultyId = 1 },
                        new Departments { Name = "Веб-разработка", Financing = 450000, FacultyId = 2 }
                    );
                    db.SaveChanges();

                    // Groups
                    db.Groups.AddRange(
                        new Groups { Name = "МАТ-11", Course = 1, DepartmentId = 1 },
                        new Groups { Name = "ПРОГ-22", Course = 2, DepartmentId = 2 },
                        new Groups { Name = "БИО-33", Course = 3, DepartmentId = 3 },
                        new Groups { Name = "МАТ-44", Course = 4, DepartmentId = 4 },
                        new Groups { Name = "ВЕБ-55", Course = 5, DepartmentId = 5 }
                    );
                    db.SaveChanges();

                    // Lectures
                    db.Lectures.AddRange(
                        new Lectures { SubjectId = 1, TeacherId = 1 }, // Математика, Иван Иванов
                        new Lectures { SubjectId = 2, TeacherId = 2 }, // Физика, Петр Петров
                        new Lectures { SubjectId = 3, TeacherId = 3 }, // Информатика, Елена Сидорова
                        new Lectures { SubjectId = 4, TeacherId = 4 }, // Химия, Алексей Кузнецов
                        new Lectures { SubjectId = 5, TeacherId = 5 }, // Биология, Ольга Смирнова
                        new Lectures { SubjectId = 1, TeacherId = 2 }, // Математика, Петр Петров
                        new Lectures { SubjectId = 3, TeacherId = 1 } // Информатика, Иван Иванов
                    );
                    db.SaveChanges();

                    // GroupsLectures
                    db.GroupsLectures.AddRange(
                        new GroupsLectures { GroupId = 1, LectureId = 1 }, // МАТ-11, Математика (Иван Иванов)
                        new GroupsLectures { GroupId = 2, LectureId = 2 }, // ПРОГ-22, Физика (Петр Петров)
                        new GroupsLectures { GroupId = 3, LectureId = 3 }, // БИО-33, Информатика (Елена Сидорова)
                        new GroupsLectures { GroupId = 4, LectureId = 4 }, // МАТ-44, Химия (Алексей Кузнецов)
                        new GroupsLectures { GroupId = 5, LectureId = 5 }, // ВЕБ-55, Биология (Ольга Смирнова)
                        new GroupsLectures { GroupId = 1, LectureId = 6 }, // МАТ-11, Математика (Петр Петров)
                        new GroupsLectures { GroupId = 2, LectureId = 7 } // ПРОГ-22, Информатика (Иван Иванов)
                    );
                    db.SaveChanges();

                    // GroupsCurators
                    db.GroupsCurators.AddRange(
                        new GroupsCurators { GroupId = 1, CuratorId = 1 }, // МАТ-11, Анна Волкова
                        new GroupsCurators { GroupId = 2, CuratorId = 2 }, // ПРОГ-22, Дмитрий Морозов
                        new GroupsCurators { GroupId = 3, CuratorId = 3 }, // БИО-33, Наталья Попова
                        new GroupsCurators { GroupId = 4, CuratorId = 1 }, // МАТ-44, Анна Волкова
                        new GroupsCurators { GroupId = 5, CuratorId = 2 } // ВЕБ-55, Дмитрий Морозов
                    );
                    db.SaveChanges();

                    Console.WriteLine("Данные успешно добавлены!\n");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Ошибка работы с БД: {ex.Message}\n{ex.InnerException?.Message}");
            }
        }
    }
}