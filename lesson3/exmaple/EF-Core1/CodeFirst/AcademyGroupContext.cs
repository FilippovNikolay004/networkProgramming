﻿using Microsoft.EntityFrameworkCore;

namespace CodeFirst
{
    // Для работы с БД MS SQL Server необходимо добавить пакет:
    // Microsoft.EntityFrameworkCore.SqlServer(представляет функциональность Entity Framework для работы с MS SQL Server)

    // Для работы с БД SQLite необходимо добавить пакет:
    // Pomelo.EntityFrameworkCore.MySql(представляет функциональность Entity Framework для работы с MySql)

    // Для работы с БД SQLite необходимо добавить пакет:
    // Microsoft.EntityFrameworkCore.Sqlite(представляет функциональность Entity Framework для работы с SQLite)

    // Lazy loading или ленивая загрузка предполагает неявную автоматическую загрузку связанных данных при обращении к навигационному свойству.
    // Microsoft.EntityFrameworkCore.Proxies

    public class AcademyGroupContext : DbContext
    {
        public AcademyGroupContext()
        {
            if (Database.EnsureCreated())
            {
                AcademyGroup group1 = new AcademyGroup { Name = "СПУ112" };
                AcademyGroup group2 = new AcademyGroup { Name = "ПВ111" };
                AcademyGroup group3 = new AcademyGroup { Name = "ПР211" };
                AcademyGroups?.Add(group1);
                AcademyGroups?.Add(group2);
                AcademyGroups?.Add(group3);
                Students?.Add(new Student { FirstName = "Богдан", LastName = "Иваненко", Age = 20, GPA = 10.5, AcademyGroup = group1 });
                Students?.Add(new Student { FirstName = "Анна", LastName = "Шевченко", Age = 23, GPA = 11.5, AcademyGroup = group2 });
                Students?.Add(new Student { FirstName = "Петро", LastName = "Петренко", Age = 25, GPA = 12, AcademyGroup = group3 });
                Students?.Add(new Student { FirstName = "Елена", LastName = "Артемьева", Age = 42, GPA = 11.5, AcademyGroup = group1 });
                Students?.Add(new Student { FirstName = "Елена", LastName = "Алексеева", Age = 47, GPA = 12, AcademyGroup = group2 });
                Students?.Add(new Student { FirstName = "Виктория", LastName = "Бабенко", Age = 29, GPA = 10, AcademyGroup = group3 });

                SaveChanges();
            }
        }

        public DbSet<AcademyGroup> AcademyGroups { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // метод UseLazyLoadingProxies() делает доступной ленивую загрузку.
            
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=LAPTOP-31VSBGAE;Database=AcademyGroupDB;Integrated Security=SSPI;TrustServerCertificate=true");


            //optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=AcademyGroup.db");
            //optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=;database=AcademyGroupDB;",
            //new MySqlServerVersion(new System.Version(10, 4, 27))); // SELECT VERSION(); команда получения версии в среде MySQL Workbench
        }
    }
}
