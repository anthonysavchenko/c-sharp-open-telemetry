using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace Simple;

public static class Telemetry
{
  public const string ServiceName = "MyConsoleService";
  public static readonly ActivitySource Source = new(ServiceName, "1.0.0");
}

public class Program
{
  public static void Main()
  {
    using var tracerProvider = Sdk.CreateTracerProviderBuilder()
      .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(Telemetry.ServiceName))
      .AddSource(Telemetry.ServiceName)
      .AddConsoleExporter()
      .Build();

    RunSampleWork();

    Console.WriteLine("\nГотово. Спаны выше выведены ConsoleExporter'ом.");
  }

  private static void RunSampleWork()
  {
    using var parentActivity = Telemetry.Source.StartActivity("ProcessOrder");
    parentActivity?.SetTag("order.id", 12345);
    parentActivity?.SetTag("order.customer", "Anton");

    DoStep("ValidateOrder", TimeSpan.FromMilliseconds(50));
    DoStep("ChargePayment", TimeSpan.FromMilliseconds(120));

    parentActivity?.SetStatus(ActivityStatusCode.Ok);
  }

  private static void DoStep(string stepName, TimeSpan simulatedDuration)
  {
    using var childActivity = Telemetry.Source.StartActivity(stepName);
    Thread.Sleep(simulatedDuration);
    childActivity?.SetStatus(ActivityStatusCode.Ok);
  }
}