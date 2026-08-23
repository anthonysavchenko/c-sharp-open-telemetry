using ConsoleDice;

using var activity = new FooBarActivity();

activity.SetTags(bar: "Hello, World!", baz: [1, 2, 3]);

while (true)
{
  Console.WriteLine("Enter the number of rolls (or 'exit' to quit):");
  var input = Console.ReadLine();

  if (input?.ToLower() == "exit")
  {
    break;
  }

  if (!int.TryParse(input, out int rolls))
  {
    Console.WriteLine("Invalid input. Please enter a valid number.");
    continue;
  }

  var result = new Dice(1, 6).RollTheDice(rolls);

  Console.WriteLine($"Rolled the dice {rolls} times: {string.Join(", ", result)}");
}
