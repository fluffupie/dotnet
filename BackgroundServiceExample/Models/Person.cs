using System.ComponentModel.DataAnnotations;

namespace BackgroundServiceExample.Models;

public class Person
{
    public int ID { get; set; }

    [Required, StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }

    public int Count { get; set; }
}
