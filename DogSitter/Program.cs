using DogSitter.BLL.Configs;
using DogSitter.BLL.Services;
using DogSitter.DAL;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

using DogSitter.API.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
