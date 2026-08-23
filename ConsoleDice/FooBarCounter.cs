using System.Diagnostics.Metrics;

namespace ConsoleDice;

public class FooBarCounter
{
  private static readonly string _counterName = "FooBarCounter";
  private readonly Counter<long> _counter;

  public FooBarCounter()
  {
    _counter = TracingWrapper.Meter.CreateCounter<long>(_counterName);
  }

  public void Add(long delta) => _counter.Add(delta);
}
