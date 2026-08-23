using ConsoleDice;

using var provider = new DiceTracerProvider();
using var source = new DiceActivitySource();
using var activity = new DiceActivity(source);

activity.SetTags(bar: "Hello, World!", baz: [1, 2, 3]);
