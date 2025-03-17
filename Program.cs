using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Services.Autor;
using WebApplication8.Services.Livro;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAutorInterface,AutorServices>();
builder.Services.AddScoped<ILivroInterface, LivroServices>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection"));
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

app.Run( );
//app.Run("http://*:5050");
