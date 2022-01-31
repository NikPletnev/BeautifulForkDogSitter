using DogSitter.DAL.Entity;
using Microsoft.EntityFrameworkCore;


namespace DogSitter.DAL
{
    public class DogSitterContext : DbContext
    {
        private const string _conectionString = @"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB; 
        Persist Security Info=True;User ID = student; Password=qwe!23; Pooling=False; MultipleActiveResultSets=False; 
        Connect Timeout = 60; Encrypt=False; TrustServerCertificate=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conectionString);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Serviсe> Services { get; set; }
        public DbSet<SubwayStation> SubwayStations { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Sitter>().ToTable("Sitter");

            #region metro
            modelBuilder.Entity<SubwayStation>().OwnsOne(s => s.Name).HasData(
                new { Id = 1, Name = "Девяткино" },
                new { Id = 2, Name = "Гражданский проспект" },
                new { Id = 3, Name = "Академическая" },
                new { Id = 4, Name = "Политехническая" },
                new { Id = 5, Name = "Площадь Мужества" },
                new { Id = 6, Name = "Лесная" },
                new { Id = 7, Name = "Выборгская" },
                new { Id = 8, Name = "Площадь Ленина" },
                new { Id = 9, Name = "Чернышевская" },
                new { Id = 10, Name = "Площадь Восстания" },
                new { Id = 11, Name = "Владимирская" },
                new { Id = 12, Name = "Пушкинская" },
                new { Id = 13, Name = "Технологический институт(1)" },
                new { Id = 14, Name = "Балтийская" },
                new { Id = 15, Name = "Нарвская" },
                new { Id = 16, Name = "Кировский завод" },
                new { Id = 17, Name = "Автово" },
                new { Id = 18, Name = "Ленинский проспект" },
                new { Id = 19, Name = "Проспект Ветеранов" },
                new { Id = 20, Name = "Парнас" },
                new { Id = 21, Name = "Проспект Просвещения" },
                new { Id = 22, Name = "Озерки" },
                new { Id = 23, Name = "Удельная" },
                new { Id = 24, Name = "Пионерская" },
                new { Id = 25, Name = "Чёрная речка" },
                new { Id = 26, Name = "Петроградская" },
                new { Id = 27, Name = "Горьковская" },
                new { Id = 28, Name = "Невский проспект" },
                new { Id = 29, Name = "Сенная площадь" },
                new { Id = 30, Name = "Технологический институт(2)" },
                new { Id = 31, Name = "Фрунзенская" },
                new { Id = 32, Name = "Московские ворота" },
                new { Id = 33, Name = "Электросила" },
                new { Id = 34, Name = "Парк Победы" },
                new { Id = 35, Name = "Московская" },
                new { Id = 36, Name = "Звёздная" },
                new { Id = 37, Name = "Купчино" },
                new { Id = 38, Name = "Беговая" },
                new { Id = 39, Name = "Зенит" },
                new { Id = 40, Name = "Приморская" },
                new { Id = 41, Name = "Василеостровская" },
                new { Id = 42, Name = "Гостиный двор" },
                new { Id = 43, Name = "Маяковская" },
                new { Id = 44, Name = "Площадь Александра Невского(1)" },
                new { Id = 45, Name = "Елизаровская" },
                new { Id = 46, Name = "Ломоносовская" },
                new { Id = 47, Name = "Пролетарская" },
                new { Id = 48, Name = "Обухово" },
                new { Id = 49, Name = "Рыбацкое" },
                new { Id = 50, Name = "Спасская" },
                new { Id = 51, Name = "Достоевская" },
                new { Id = 52, Name = "Лиговский проспект" },
                new { Id = 53, Name = "Площадь Александра Невского(2)" },
                new { Id = 54, Name = "Новочеркасская" },
                new { Id = 55, Name = "Ладожская" },
                new { Id = 56, Name = "Проспект Большевиков" },
                new { Id = 57, Name = "Улица Дыбенко" },
                new { Id = 58, Name = "Комендантский проспект" },
                new { Id = 59, Name = "Старая Деревня" },
                new { Id = 60, Name = "Крестовский остров" },
                new { Id = 61, Name = "Чкаловская" },
                new { Id = 62, Name = "Спортивная" },
                new { Id = 63, Name = "Адмиралтейская" },
                new { Id = 64, Name = "Садовая" },
                new { Id = 65, Name = "Звенигородская" },
                new { Id = 66, Name = "Обводный канал" },
                new { Id = 67, Name = "Волковская" },
                new { Id = 68, Name = "Бухарестская" },
                new { Id = 69, Name = "Международная" },
                new { Id = 70, Name = "Проспект Славы" },
                new { Id = 71, Name = "Дунайская" },
                new { Id = 72, Name = "Шушуары" }
                );
                #endregion

        }

    }
}
