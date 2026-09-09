using JsonParsing;
using Newtonsoft.Json;

var json = File.ReadAllText("Data/People.json");

Console.WriteLine(json);

// NOTE: Can also use List<Person> instead of an array.
var people = JsonConvert.DeserializeObject<Person[]>(json);

foreach(var person in people)
{
    Console.WriteLine($"{person.FirstName} {person.LastName}");
}
