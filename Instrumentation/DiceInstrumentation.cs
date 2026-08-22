using System.Diagnostics;

namespace Instrumentation;

/// <summary>
/// It is recommended to use a custom type to hold references for ActivitySource.
/// This avoids possible type collisions with other components in the DI container.
/// </summary>
public class DiceInstrumentation : IDisposable
{
  internal const string ActivitySourceName = "dice-server";
  internal const string ActivitySourceVersion = "1.0.0";

  public DiceInstrumentation()
  {
    ActivitySource = new ActivitySource(ActivitySourceName, ActivitySourceVersion);
  }

  public ActivitySource ActivitySource { get; }

  public void Dispose()
  {
    ActivitySource.Dispose();
  }
}
