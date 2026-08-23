using System.Diagnostics;

namespace ConsoleDice;

public sealed class DiceActivitySource : IDisposable
{
  public static readonly string SourceName = "ConsoleDice.Dice";

  private readonly ActivitySource _activitySource;

  public DiceActivitySource()
  {
    _activitySource = new ActivitySource(SourceName);
  }

  public Activity? StartActivity(string activityName)
  {
    return _activitySource.StartActivity(activityName);
  }

  public void Dispose()
  {
    _activitySource.Dispose();
  }
}
