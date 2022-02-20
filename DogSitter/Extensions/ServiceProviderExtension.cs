using DogSitter.BLL.Configs;
using DogSitter.BLL.Services;
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
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IPassportService, PassportService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ISitterService, SitterService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISubwayStationService, SubwayStationService>();
            services.AddScoped<IWorkTimeService, WorkTimeService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<ICommentService, CommentService>();
        }

        public static void RegisterDogSitterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IPassportRepository, PassportRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISitterRepository, SitterRepository>();
            services.AddScoped<ISubwayStationRepository, SubwayStationRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IWorkTimeRepository, WorkTimeRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
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
                    @"Server=(localdb)\mssqllocaldb;Database=DogSitterDB2;Trusted_Connection=True;"));


            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = DogSitterDB;
            //                Integrated Security=True;Connect 
            //                Timeout=30;Encrypt=False;TrustServerCertificate=False;
            //                ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));


            //@"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB;
            //Persist Security Info=True; User ID = student; Password = qwe!23; Pooling = False; 
            //MultipleActiveResultSets = False; Connect Timeout = 60; Encrypt = False; 
            //TrustServerCertificate = False"));
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
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

