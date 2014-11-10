using System.Collections.Generic;

namespace prep.utility
{
  public static class FilteringExtensions
  {
    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
      Condition<T> condition)
    {
      foreach (var item in items)
      {
        if (condition(item))
          yield return item;
      }
    }
  }
}