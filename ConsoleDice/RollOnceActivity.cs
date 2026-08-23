using System.Diagnostics;

namespace ConsoleDice;

public sealed class RollOnceActivity : IDisposable
{
  private static readonly string ActivityName = "roll-once";

  private readonly Activity? _activity;

  public RollOnceActivity()
  {
    _activity = TracingWrapper.ActivitySource.StartActivity(ActivityName);
  }

  public void SetTags(int rollResult)
  {
    _activity?.SetTag("roll-result", rollResult);
  }

  public void Dispose()
  {
    _activity?.Dispose();
  }
}
