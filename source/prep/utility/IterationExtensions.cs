using System.Collections.Generic;

namespace prep.utility
{
  public static class IterationExtensions
  {
    public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items )
    {
      foreach (var item in items)
        yield return item;
    }
  }
}