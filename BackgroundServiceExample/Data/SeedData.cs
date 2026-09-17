using BackgroundServiceExample.Models;

namespace BackgroundServiceExample.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<PeopleContext>();

        // Look for any people.
        if(context.Persons.Any())
            return; // DB has already been seeded.

        context.Persons.AddRange(
            new Person
            {
                Name = "Nina",
                Count = 0
            },
            new Person
            {
                Name = "Sandra",
                Count = 10
            });

        context.SaveChanges();
    }
}
