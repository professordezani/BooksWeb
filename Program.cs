using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;

var builder = WebApplication.CreateBuilder(args);

// middleware
builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<BookDatabase>(options => options.UseInMemoryDatabase("db"));
builder.Services.AddDbContext<BookDatabase>(options => options.UseSqlite("Data Source=books.db"));


var app = builder.Build();

app.MapControllerRoute("default", "/{controller=Book}/{action=Read}");

app.Run();
