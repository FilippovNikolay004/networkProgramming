using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using homework;

namespace PromoMailingDB {
    class MainClass {
        static string? connectionString;

        static void Main() {
            var builder = new ConfigurationBuilder();
            string path = Directory.GetCurrentDirectory();
            builder.SetBasePath(path);
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");

            try {
                while (true) {
                    Console.Clear();
                    Console.WriteLine("1. Отображение всех покупателей");
                    Console.WriteLine("2. Отображение email всех покупателей");
                    Console.WriteLine("3. Отображение списка разделов");
                    Console.WriteLine("4. Отображение списка акционных товаров");
                    Console.WriteLine("5. Отображение всех городов");
                    Console.WriteLine("6. Отображение всех стран");
                    Console.WriteLine("7. Отображение всех покупателей из конкретного города");
                    Console.WriteLine("8. Отображение всех покупателей из конкретной страны");
                    Console.WriteLine("9. Отображение всех акций для конкретной страны");
                    Console.WriteLine("0. Выход");
                    int result = int.Parse(Console.ReadLine()!);
                    switch (result) {
                    case 1:
                        ShowAllCustomers();
                        break;
                    case 2:
                        ShowAllCustomerEmails();
                        break;
                    case 3:
                        ShowAllSections();
                        break;
                    case 4:
                        ShowAllPromotionalProducts();
                        break;
                    case 5:
                        ShowAllCities();
                        break;
                    case 6:
                        ShowAllCountries(); 
                        break;
                    case 7:
                        ShowCustomersByCity("Алматы"); 
                        break;
                    case 8:
                        ShowCustomersByCountry("США"); 
                        break;
                    case 9:
                        ShowPromotionsByCountry("США"); 
                        break;
                    case 0:
                        return;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void ShowAllCustomers() {
            // Реализация метода для отображения всех покупателей
            Console.Clear();
            Console.WriteLine("Вывод всех покупателей...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<Buyer>("SELECT * FROM Buyers " );
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.FirstName,15}");
                    Console.Write($"{st.LastName,15}");
                    Console.Write($"{st.DateOfBirth,10}");
                    Console.Write($"{st.Gender,10}");
                    Console.Write($"{st.Email,10}");
                    Console.Write($"{st.Country,10}");
                    Console.Write($"{st.City,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowAllCustomerEmails() {
            // Реализация метода для отображения email всех покупателей
            Console.Clear();
            Console.WriteLine("Вывод email всех покупателей...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<Buyer>("SELECT Buyers.Email FROM Buyers");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.Email,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowAllSections() {
            // Реализация метода для отображения списка разделов
            Console.Clear();
            Console.WriteLine("Вывод списка разделов...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<ListSections>("SELECT * FROM ListSections");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.MobilePhone,15}");
                    Console.Write($"{st.Laptop,15}");
                    Console.Write($"{st.KitchenAppliances,10}");
                    Console.Write($"{st.Tablets,10}");
                    Console.Write($"{st.TVs,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowAllPromotionalProducts() {
            // Реализация метода для отображения списка акционных товаров
            Console.Clear();
            Console.WriteLine("Вывод списка акционных товаров...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<ListSections>("SELECT * FROM DiscountedItems JOIN ListSections " +
                    "ON DiscountedItems.ListSectionsId = ListSections.Id");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.MobilePhone,15}");
                    Console.Write($"{st.Laptop,15}");
                    Console.Write($"{st.KitchenAppliances,10}");
                    Console.Write($"{st.Tablets,10}");
                    Console.Write($"{st.TVs,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowAllCities() {
            // Реализация метода для отображения всех городов
            Console.Clear();
            Console.WriteLine("Вывод всех городов...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<Buyer>("SELECT Buyers.City FROM Buyers");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.City,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowAllCountries() {
            // Реализация метода для отображения всех стран
            Console.Clear();
            Console.WriteLine("Вывод всех стран...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<CountryStocks>("SELECT CountriesStocks.NameCountry FROM CountriesStocks");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.NameCountry,10}\n");
                }
            }
            Console.ReadKey();
        }


        static void ShowCustomersByCity(string nameSity) {
            // Реализация метода для отображения всех покупателей из конкретного города
            Console.Clear();
            Console.WriteLine("Вывод покупателей по городу...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<Buyer>($"SELECT * FROM Buyers WHERE Buyers.City = '{nameSity}'");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.FirstName,15}");
                    Console.Write($"{st.LastName,15}");
                    Console.Write($"{st.DateOfBirth,10}");
                    Console.Write($"{st.Gender,10}");
                    Console.Write($"{st.Email,10}");
                    Console.Write($"{st.Country,10}");
                    Console.Write($"{st.City,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowCustomersByCountry(string nameCountry) {
            // Реализация метода для отображения всех покупателей из конкретной страны
            Console.Clear();
            Console.WriteLine("Вывод покупателей по стране...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<Buyer>($"SELECT * FROM Buyers WHERE Buyers.Country = '{nameCountry}'");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.FirstName,15}");
                    Console.Write($"{st.LastName,15}");
                    Console.Write($"{st.DateOfBirth,10}");
                    Console.Write($"{st.Gender,10}");
                    Console.Write($"{st.Email,10}");
                    Console.Write($"{st.Country,10}");
                    Console.Write($"{st.City,10}\n");
                }
            }
            Console.ReadKey();
        }

        static void ShowPromotionsByCountry(string nameCountry) {
            // Реализация метода для отображения всех акций для конкретной страны
            Console.Clear();
            Console.WriteLine("Вывод акций по стране...");
            using (IDbConnection db = new SqlConnection(connectionString)) {
                var students = db.Query<CountryStocks>($"SELECT * FROM CountriesStocks WHERE CountriesStocks.NameCountry = '{nameCountry}'");
                int iter = 0;
                foreach (var st in students) {
                    Console.Write($"#{++iter}: {st.NameCountry,10}");
                    Console.Write($"{st.Discount,10}\n");
                }
            }
            Console.ReadKey();
        }
    }
}