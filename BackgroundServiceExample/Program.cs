// This file is the application startup for the ASP.NET Core project. It configures the app, registers services, seeds the database, and starts the web app.

using BackgroundServiceExample.BackgroundServices;
using BackgroundServiceExample.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); // creates the app builder, which is used to configure the app and register services. 

// database configuration
builder.Services.AddDbContext<PeopleContext>(options =>
{
    // This tells ASP.NET Core to create a PeopleContext whenever the app needs it, using SQL Server.
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(PeopleContext)));
});

// Register PeopleBackgroundService to automatically run in the background while the app is active
// That means the host runs it automatically when the app starts.
builder.Services.AddHostedService<PeopleBackgroundService>();

// Bonus Material: Can configure the host options for background services.
// NOTE: The default behavior is BackgroundServiceExceptionBehavior.StopHost.
//builder.Services.Configure<HostOptions>(options =>
//{
//    options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore;
//});

// Add MVC support
builder.Services.AddControllersWithViews();

var app = builder.Build(); // builds the app

// Seed initial data.
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch(Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) // If not running in Development mode, it configures a global exception page.
    app.UseExceptionHandler("/Home/Error");

//app.UseHttpsRedirection();
app.UseRouting(); // configures routing
app.UseAuthorization(); // configures authorization

app.MapStaticAssets(); // configures static files

app.MapDefaultControllerRoute().WithStaticAssets();

app.Run(); // run the app
