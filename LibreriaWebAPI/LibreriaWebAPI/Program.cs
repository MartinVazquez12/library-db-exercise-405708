using LibreriaWebAPI.Context;
using LibreriaWebAPI.Repository;
using LibreriaWebAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Patron Repository
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<IGeneroRepository, GeneroRepository>();


//DbContext
builder.Services.AddDbContext<LibroDbContext>((context) =>
{
   context.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaDb"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//CORS
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
