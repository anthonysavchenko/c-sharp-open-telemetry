using System.Diagnostics;

namespace ConsoleDice;

public sealed class DiceActivity : IDisposable
{
  private static readonly string ActivityName = "dice-roll";

  private readonly Activity? _activity;

  public DiceActivity(DiceActivitySource activitySource)
  {
    _activity = activitySource.StartActivity(ActivityName);

    _activity?.SetTag("foo", 1);
  }

  public void SetTags(string bar, int[] baz)
  {
    _activity?.SetTag("bar", bar);
    _activity?.SetTag("baz", baz);
  }

  public void Dispose()
  {
    _activity?.SetTag("quz", "quux");

    _activity?.SetStatus(ActivityStatusCode.Ok);

    _activity?.Dispose();
  }
}
