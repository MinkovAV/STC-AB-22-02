using Microsoft.EntityFrameworkCore;
using MyCoolApp.Metods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DB_Context>(opt =>
{
    var config = builder.Configuration;

    var Host = config["Host"] ?? "";
    var port = config["Port"] ?? "5432";
    var username = config["User ID"] ?? "";
    var password = config["Password"] ?? "";
    var db_name = config["Database"] ?? "testDB";

    var connectionString = $"User ID={username};Password={password};Host={Host};Port={port};Database={db_name};Integrated Security=true;Pooling=true";

    opt.UseNpgsql(connectionString);
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

app.MapControllers();

app.Run();
