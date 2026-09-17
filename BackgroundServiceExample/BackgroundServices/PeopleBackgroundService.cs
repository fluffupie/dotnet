// This file creates a service that keeps running in the background while the ASP.NET app is alive.
// It does not respond to web requests directly; instead, it periodically updates database records.
using BackgroundServiceExample.Data;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceExample.BackgroundServices;

// PeopleBackgoundService inherits from BackgroundService, which is ASP.NET Core's built-in base class for implementing long-running background services.
public class PeopleBackgroundService : BackgroundService
{
    private readonly IServiceProvider _services; // an IServiceProvider to create a database context safely
    private readonly ILogger<PeopleBackgroundService> _logger; // an ILogger to log information about the background service's activity

    public PeopleBackgroundService(IServiceProvider services, ILogger<PeopleBackgroundService> logger)
    {
        _services = services;
        _logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken) // Checks the database every minute.
    {
        _logger.LogInformation("People Background Service is running."); // Log that the background service has started.

        while(!cancellationToken.IsCancellationRequested) // Keep running until the host is shutting down (cancellationToken is triggered).
        {
            await DoWorkAsync(cancellationToken); // Calls DoWorkAsync to perform the actual work of the background service (updating database records).

            _logger.LogInformation("People Background Service is waiting a minute.");

            await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken); // Wait for a minute before running the work again. The delay can be cancelled if the host is shutting down (cancellationToken is triggered).
            // So the work repeats every minute.
        }
    }

    private async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("People Background Service is working.");

        using var scope = _services.CreateScope(); // Create a new scope for the database context. This is important because the background service runs in a different thread than the web server, and we need to create a new scope for the database context to avoid issues with dependency injection.
        var context = scope.ServiceProvider.GetRequiredService<PeopleContext>();

        var persons = await context.Persons.ToListAsync(cancellationToken); // Get all the Person records from the database. This is done asynchronously to avoid blocking the thread.
        
        foreach(var person in persons) // loop through each Person record and update their Count property based on their Name.
        {
            // Name's starting with an S have count incremented by 5, everyone else has count incremented by 1.
            if(person.Name.StartsWith('S'))
                person.Count += 5;
            else
                person.Count++;
        }

        await context.SaveChangesAsync(cancellationToken); // Save the changes to the database asynchronously. This is done asynchronously to avoid blocking the thread.

        _logger.LogInformation("People Background Service work complete.");
    }
}
