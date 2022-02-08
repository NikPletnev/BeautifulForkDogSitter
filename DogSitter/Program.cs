using DogSitter.API.Configs;
using DogSitter.BLL.Services;
using DogSitter.DAL;
using DogSitter.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomMapper, CustomMapper>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddDbContext<DogSitterContext>(
    options => options.UseSqlServer(@"Data Source = 80.78.240.16; Initial Catalog = DogSitterDB; 
        Persist Security Info=True;User ID = student; Password=qwe!23; Pooling=False; MultipleActiveResultSets=False; 
        Connect Timeout = 60; Encrypt=False; TrustServerCertificate=False"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
