using DogSitter.API.Extensions;
using DogSitter.API.Infrastructure;
using DogSitter.BLL.Configs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(CustomMapper).Assembly, typeof(CustomMapper).Assembly);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.RegisterDogSitterServices();
builder.Services.RegisterDogSitterRepositories();
builder.Services.AddCustomAuth();
builder.Services.AddConnectionString();
builder.Services.AddSwagger();

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
