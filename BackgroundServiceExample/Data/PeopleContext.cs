using BackgroundServiceExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BackgroundServiceExample.Data;

public class PeopleContext : DbContext
{
    public PeopleContext(DbContextOptions<PeopleContext> options) : base(options)
    { }

    public DbSet<Person> Persons { get; set; }
}
