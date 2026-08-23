using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

const string DiceActivitySourceName = "ConsoleDice.Dice";

using var tracerProvider = Sdk
  .CreateTracerProviderBuilder()
  .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("getting-started"))
  .AddSource(DiceActivitySourceName)
  .AddConsoleExporter()
  .Build();

var DiceActivitySource = new ActivitySource(DiceActivitySourceName);

using var activity = DiceActivitySource.StartActivity("SayHello");

activity?.SetTag("foo", 1);
activity?.SetTag("bar", "Hello, World!");
activity?.SetTag("baz", new int[] { 1, 2, 3 });

activity?.SetStatus(ActivityStatusCode.Ok);
