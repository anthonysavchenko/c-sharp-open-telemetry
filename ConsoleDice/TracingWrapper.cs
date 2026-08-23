using System.Diagnostics;
using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ConsoleDice;

public sealed class TracingWrapper
{
  private static readonly string _serviceName = "my-service-name";
  private static readonly string _libName = "MyCompany.MyProduct.MyLibrary";

  private static readonly TracerProvider _tracerProvider = Sdk
    .CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(_serviceName))
    .AddSource(_libName)
    .AddConsoleExporter()
    .Build();

  private static readonly MeterProvider _meterProvider = Sdk
    .CreateMeterProviderBuilder()
    .AddMeter(_libName)
    .AddConsoleExporter()
    .Build();

  public static readonly ActivitySource ActivitySource = new(_libName);

  public static readonly Meter Meter = new(_libName);

  public static void Dispose()
  {
    ActivitySource.Dispose();
    _tracerProvider.Dispose();

    Meter.Dispose();
    _meterProvider.Dispose();
  }
}
