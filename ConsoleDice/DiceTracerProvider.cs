using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ConsoleDice;

public sealed class DiceTracerProvider : IDisposable
{
  private readonly TracerProvider _tracerProvider;

  public DiceTracerProvider()
  {
    _tracerProvider = Sdk
      .CreateTracerProviderBuilder()
      .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("dice-service"))
      .AddSource(DiceActivitySource.SourceName)
      .AddConsoleExporter()
      .Build();
  }

  public void Dispose()
  {
    _tracerProvider.Dispose();
  }
}
