using DogSitter.DAL.Entity;
using DogSitter.DAL.Enums;
using Microsoft.EntityFrameworkCore;


namespace DogSitter.DAL
{
    public class DogSitterContext : DbContext
    {

        public DogSitterContext(DbContextOptions<DogSitterContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sitter> Sitters { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Serviсe> Services { get; set; }
        public DbSet<SubwayStation> SubwayStations { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<BusyTime> BusyTimes { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Sitter>().ToTable("Sitters");

            modelBuilder.Entity<Contact>(entity => entity.HasIndex(e => e.Value).IsUnique());

            #region Default 

            modelBuilder.Entity<Sitter>()
            .Property(w => w.Role)
            .HasDefaultValue((Role)3);

            modelBuilder.Entity<Customer>()
            .Property(w => w.Role)
            .HasDefaultValue((Role)2);

            modelBuilder.Entity<Admin>()
            .Property(w => w.Role)
            .HasDefaultValue((Role)1);

            modelBuilder.Entity<Sitter>()
            .Property(w => w.Verified)
            .HasDefaultValue(0);

            modelBuilder.Entity<Order>()
            .Property(a => a.Status)
            .HasDefaultValue((Status)1);

            modelBuilder.Entity<Address>()
            .Property(a => a.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Admin>()
            .Property(a => a.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Comment>()
            .Property(c => c.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Contact>()
            .Property(c => c.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Customer>()
            .Property(c => c.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Dog>()
            .Property(d => d.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Order>()
            .Property(o => o.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Passport>()
            .Property(p => p.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Serviсe>()
            .Property(s => s.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Sitter>()
            .Property(s => s.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<SubwayStation>()
            .Property(s => s.IsDeleted)
            .HasDefaultValue(0);

            modelBuilder.Entity<Timesheet>()
            .Property(w => w.IsDeleted)
            .HasDefaultValue(0);

            #endregion

            #region Subway Stations
            modelBuilder.Entity<SubwayStation>().HasData(
                            new SubwayStation[]
                            {
                new SubwayStation { Id = 1, Name = "Девяткино", IsDeleted = false },
                new SubwayStation { Id = 2, Name = "Гражданский проспект", IsDeleted = false },
                new SubwayStation { Id = 3, Name = "Академическая",IsDeleted = false },
                new SubwayStation { Id = 4, Name = "Политехническая", IsDeleted = false },
                new SubwayStation { Id = 5, Name = "Площадь Мужества", IsDeleted = false },
                new SubwayStation { Id = 6, Name = "Лесная", IsDeleted = false },
                new SubwayStation { Id = 7, Name = "Выборгская", IsDeleted = false },
                new SubwayStation { Id = 8, Name = "Площадь Ленина", IsDeleted = false},
                new SubwayStation { Id = 9, Name = "Чернышевская", IsDeleted = false },
                new SubwayStation { Id = 10, Name = "Площадь Восстания" },
                new SubwayStation { Id = 11, Name = "Владимирская", IsDeleted = false },
                new SubwayStation { Id = 12, Name = "Пушкинская", IsDeleted = false },
                new SubwayStation { Id = 13, Name = "Технологический институт(1)", IsDeleted = false },
                new SubwayStation { Id = 14, Name = "Балтийская", IsDeleted = false },
                new SubwayStation { Id = 15, Name = "Нарвская", IsDeleted = false },
                new SubwayStation { Id = 16, Name = "Кировский завод", IsDeleted = false },
                new SubwayStation { Id = 17, Name = "Автово", IsDeleted = false },
                new SubwayStation { Id = 18, Name = "Ленинский проспект", IsDeleted = false },
                new SubwayStation { Id = 19, Name = "Проспект Ветеранов", IsDeleted = false },
                new SubwayStation { Id = 20, Name = "Парнас", IsDeleted = false },
                new SubwayStation { Id = 21, Name = "Проспект Просвещения", IsDeleted = false },
                new SubwayStation { Id = 22, Name = "Озерки", IsDeleted = false },
                new SubwayStation { Id = 23, Name = "Удельная", IsDeleted = false },
                new SubwayStation { Id = 24, Name = "Пионерская", IsDeleted = false },
                new SubwayStation { Id = 25, Name = "Чёрная речка", IsDeleted = false },
                new SubwayStation { Id = 26, Name = "Петроградская", IsDeleted = false },
                new SubwayStation { Id = 27, Name = "Горьковская", IsDeleted = false },
                new SubwayStation { Id = 28, Name = "Невский проспект", IsDeleted = false },
                new SubwayStation { Id = 29, Name = "Сенная площадь", IsDeleted = false },
                new SubwayStation { Id = 30, Name = "Технологический институт(2)", IsDeleted = false },
                new SubwayStation { Id = 31, Name = "Фрунзенская", IsDeleted = false },
                new SubwayStation { Id = 32, Name = "Московские ворота", IsDeleted = false },
                new SubwayStation { Id = 33, Name = "Электросила", IsDeleted = false },
                new SubwayStation { Id = 34, Name = "Парк Победы", IsDeleted = false },
                new SubwayStation { Id = 35, Name = "Московская", IsDeleted = false },
                new SubwayStation { Id = 36, Name = "Звёздная", IsDeleted = false },
                new SubwayStation { Id = 37, Name = "Купчино", IsDeleted = false },
                new SubwayStation { Id = 38, Name = "Беговая", IsDeleted = false },
                new SubwayStation { Id = 39, Name = "Зенит", IsDeleted = false },
                new SubwayStation { Id = 40, Name = "Приморская", IsDeleted = false },
                new SubwayStation { Id = 41, Name = "Василеостровская", IsDeleted = false },
                new SubwayStation { Id = 42, Name = "Гостиный двор", IsDeleted = false },
                new SubwayStation { Id = 43, Name = "Маяковская", IsDeleted = false },
                new SubwayStation { Id = 44, Name = "Площадь Александра Невского(1)", IsDeleted = false },
                new SubwayStation { Id = 45, Name = "Елизаровская", IsDeleted = false },
                new SubwayStation { Id = 46, Name = "Ломоносовская", IsDeleted = false },
                new SubwayStation { Id = 47, Name = "Пролетарская", IsDeleted = false },
                new SubwayStation { Id = 48, Name = "Обухово", IsDeleted = false },
                new SubwayStation { Id = 49, Name = "Рыбацкое", IsDeleted = false },
                new SubwayStation { Id = 50, Name = "Спасская", IsDeleted = false },
                new SubwayStation { Id = 51, Name = "Достоевская", IsDeleted = false },
                new SubwayStation { Id = 52, Name = "Лиговский проспект", IsDeleted = false },
                new SubwayStation { Id = 53, Name = "Площадь Александра Невского(2)", IsDeleted = false },
                new SubwayStation { Id = 54, Name = "Новочеркасская", IsDeleted = false },
                new SubwayStation { Id = 55, Name = "Ладожская", IsDeleted = false },
                new SubwayStation { Id = 56, Name = "Проспект Большевиков", IsDeleted = false },
                new SubwayStation { Id = 57, Name = "Улица Дыбенко", IsDeleted = false },
                new SubwayStation { Id = 58, Name = "Комендантский проспект", IsDeleted = false },
                new SubwayStation { Id = 59, Name = "Старая Деревня", IsDeleted = false },
                new SubwayStation { Id = 60, Name = "Крестовский остров", IsDeleted = false },
                new SubwayStation { Id = 61, Name = "Чкаловская", IsDeleted = false },
                new SubwayStation { Id = 62, Name = "Спортивная", IsDeleted = false },
                new SubwayStation { Id = 63, Name = "Адмиралтейская", IsDeleted = false },
                new SubwayStation { Id = 64, Name = "Садовая", IsDeleted = false },
                new SubwayStation { Id = 65, Name = "Звенигородская", IsDeleted = false },
                new SubwayStation { Id = 66, Name = "Обводный канал", IsDeleted = false },
                new SubwayStation { Id = 67, Name = "Волковская", IsDeleted = false },
                new SubwayStation { Id = 68, Name = "Бухарестская", IsDeleted = false },
                new SubwayStation { Id = 69, Name = "Международная", IsDeleted = false },
                new SubwayStation { Id = 70, Name = "Проспект Славы", IsDeleted = false },
                new SubwayStation { Id = 71, Name = "Дунайская", IsDeleted = false },
                new SubwayStation { Id = 72, Name = "Шушуары", IsDeleted = false }
                            });
            #endregion


        }

    }
}
