using Microsoft.EntityFrameworkCore;
using NorthwindWithPagingExample.Data;

// NOTE: You can use logging settings in appsettings.json or create a console logger to see queries EF Core generates.
var consoleLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<NorthwindContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(NorthwindContext)));

    // The console logger can be used to see queries EF Core generates.
    options.UseLoggerFactory(consoleLoggerFactory);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Make the session cookie essential.
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();

app.MapDefaultControllerRoute().WithStaticAssets();

app.Run();
