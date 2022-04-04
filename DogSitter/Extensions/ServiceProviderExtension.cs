using DogSitter.BLL.Configs;
using DogSitter.BLL.Services;
using DogSitter.BLL.Services.Interfaces;
using DogSitter.DAL;
using DogSitter.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace DogSitter.API.Extensions
{
    public static class ServiceProviderExtension
    {
        public static void RegisterDogSitterServices(this IServiceCollection services)
        {
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDogService, DogService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPassportService, PassportService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ISitterService, SitterService>();
            services.AddScoped<ISubwayStationService, SubwayStationService>();
            services.AddScoped<IWorkTimeService, WorkTimeService>();
        }

        public static void RegisterDogSitterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDogRepository, DogRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IPassportRepository, PassportRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ISitterRepository, SitterRepository>();
            services.AddScoped<ISubwayStationRepository, SubwayStationRepository>();
            services.AddScoped<IBusyTimeRepository, BusyTimeRepository>();
            services.AddScoped<ITimesheetRepository, TimesheetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddCustomAuth(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // указывает, будет ли валидироваться издатель при валидации токена
            ValidateIssuer = true,
            // строка, представляющая издателя
            ValidIssuer = AuthOptions.Issuer,
            // будет ли валидироваться потребитель токена
            ValidateAudience = true,
            // установка потребителя токена
            ValidAudience = AuthOptions.Audience,
            // будет ли валидироваться время существования
            ValidateLifetime = true,
            // установка ключа безопасности
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // валидация ключа безопасности
            ValidateIssuerSigningKey = true,
        };
    });
            services.AddAuthorization();
        }

        public static void AddConnectionString(this IServiceCollection services)
        {
            services.AddDbContext<DogSitterContext>(
                options => options.UseSqlServer(
            @"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB;
            Persist Security Info=True; User ID = student; Password = qwe!23; Pooling = False; 
            MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; 
            TrustServerCertificate = False"));
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.EnableAnnotations();
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                             new string[]{}
                    }
                });
            });
        }


    }
}

