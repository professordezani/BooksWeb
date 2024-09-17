var builder = WebApplication.CreateBuilder(args);

// middleware
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapControllerRoute("default", "/{controller=Book}/{action=Read}");

app.Run();
