namespace ConsoleDice;

public class Dice(int min, int max)
{
  private readonly int _min = min;
  private readonly int _max = max;

  public List<int> RollTheDice(int rolls)
  {
    using var rollingDiceActivity = new RollingDiceActivity();

    var results = new List<int>();

    for (int i = 0; i < rolls; i++)
    {
      results.Add(RollOnce());
    }

    return results;
  }

  private int RollOnce()
  {
    using var rollOnceActivity = new RollOnceActivity();

    int result = Random.Shared.Next(_min, _max + 1);

    rollOnceActivity.SetTags(result);

    return result;
  }
}
