using System.Collections.Generic;
using prep.core;

namespace prep.matching
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

    public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items,
      IMatchA<T> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static LazyFiltering<ItemToFilter, AttributeType> where<ItemToFilter, AttributeType>(this IEnumerable<ItemToFilter> items,
      IGetAnAttributeValue<ItemToFilter, AttributeType> accessor)
    {
      return new LazyFiltering<ItemToFilter, AttributeType>(items,
        Match<ItemToFilter>.with_attribute(accessor));
    }

    public class LazyFiltering<T, AttributeType>
    {
      IEnumerable<T> items_to_filter;
      IProvideAccessToCreateMatchers<T, AttributeType> extension_point;

      public LazyFiltering(IEnumerable<T> items_to_filter,
        IProvideAccessToCreateMatchers<T, AttributeType> extension_point)
      {
        this.items_to_filter = items_to_filter;
        this.extension_point = extension_point;
      }

      public IEnumerable<T> equal_to(AttributeType value)
      {
        return items_to_filter.all_items_matching(extension_point.equal_to(value));
      }
    }
  }
}