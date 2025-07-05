using API.Middleware;
using Domain.Interface;
using Domain.Model;
using Infrastructure.persistence.Data;
using Infrastructure.persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Abstraction;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("con1"));
});


builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();



// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
