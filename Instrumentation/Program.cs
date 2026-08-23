using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using Microsoft.Extensions.Logging;
using Instrumentation;

var serviceName = "MyServiceName";
var serviceVersion = "1.0.0";

var tracerProvider = Sdk.CreateTracerProviderBuilder()
    .AddSource(serviceName)
    .ConfigureResource(resource =>
        resource.AddService(
          serviceName: serviceName,
          serviceVersion: serviceVersion))
    .AddConsoleExporter()
    .Build();

var meterProvider = Sdk.CreateMeterProviderBuilder()
    .AddMeter(serviceName)
    .AddConsoleExporter()
    .Build();

var loggerFactory = LoggerFactory.Create(builder =>
{
  builder.AddOpenTelemetry(logging =>
  {
    logging.AddConsoleExporter();
  });
});

using var instrumentation = new DiceInstrumentation();
var activitySource = instrumentation.ActivitySource;

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

  var result = new Dice(1, 6, activitySource).rollTheDice(rolls);

  Console.WriteLine($"Rolled the dice {rolls} times: {string.Join(", ", result)}");
}

tracerProvider.Dispose();
meterProvider.Dispose();
loggerFactory.Dispose();
