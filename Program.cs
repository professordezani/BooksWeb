using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
// using Microsoft.EntityFrameworkCore.Sqlite;
// using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// middleware
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookDatabase>(options => options.UseInMemoryDatabase("db"));
// builder.Services.AddDbContext<BookDatabase>(options => options.UseSqlite("Data Source=books.db"));

// var connString = "Server=DESKTOP-PROF-LA\\MSSQLSERVER182;Database=dbooks;Trusted_Connection=True;TrustServerCertificate=True";
// builder.Services.AddDbContext<BookDatabase>(options => options.UseSqlServer(connString));
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();
app.MapControllerRoute("default", "/{controller=Reader}/{action=Login}/{id?}");

app.Run();
