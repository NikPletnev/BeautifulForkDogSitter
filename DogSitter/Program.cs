using DogSitter.BLL.Configs;
using DogSitter.BLL.Services;
using DogSitter.DAL;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

using DogSitter.API.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DogSitter.API.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(CustomMapperAPI).Assembly, typeof(CustomMapper).Assembly);

builder.Services.AddControllers();

builder.Services.AddDbContext<DogSitterContext>(
    options => options.UseSqlServer(@"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB;
Persist Security Info=True; User ID = student; Password = qwe!23; Pooling = False; MultipleActiveResultSets = False;
Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IPassportService, PassportService>();
builder.Services.AddScoped<IPassportRepository, PassportRepository>();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ISitterRepository, SitterRepository>();
builder.Services.AddScoped<ISitterService, SitterService>();


builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<GlobalExeptionHandler>();

app.MapControllers();

app.Run();
