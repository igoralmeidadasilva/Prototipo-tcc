using Microsoft.EntityFrameworkCore;
using tcc.api.Data;
using tcc.api.Models;
using tcc.api.Repositories;
using tcc.api.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbRepository<EntityModel>, EntityRepository>();
builder.Services.AddScoped<IDbRepository<NamedEntityModel>, NamedEntityRepository>();

var connection = builder.Configuration["ConnectionStrings:SqliteConnectionString"];
builder.Services.AddDbContext<DataContext>(
    options => options.UseSqlite(connection)
);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://127.0.0.1:5500")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

