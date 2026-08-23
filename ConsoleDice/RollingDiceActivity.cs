using System.Diagnostics;

namespace ConsoleDice;

public sealed class RollingDiceActivity : IDisposable
{
  private static readonly string ActivityName = "rolling-dice";

  private readonly Activity? _activity;

  public RollingDiceActivity()
  {
    _activity = TracingWrapper.ActivitySource.StartActivity(ActivityName);
  }

  public void Dispose()
  {
    _activity?.Dispose();
  }
}
