using Microsoft.EntityFrameworkCore;
using RepositoryPattern;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var cons = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer(cons.ToString()));
builder.Services.AddTransient<IRepository<User>, Repository<User>>();
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
