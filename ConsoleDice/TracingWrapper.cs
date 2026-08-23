using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ConsoleDice;

public sealed class TracingWrapper
{
  private static readonly string _seriveName = "my-service-name";
  private static readonly string _sourceName = "MyCompany.MyProduct.MyLibrary";

  private static readonly TracerProvider _tracerProvider = Sdk
    .CreateTracerProviderBuilder()
    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(_seriveName))
    .AddSource(_sourceName)
    .AddConsoleExporter()
    .Build();

  public static readonly ActivitySource ActivitySource = new(_sourceName);

  public static void Dispose()
  {
    ActivitySource.Dispose();
    _tracerProvider.Dispose();
  }
}
