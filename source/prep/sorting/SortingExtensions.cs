using System;
using System.Collections.Generic;
using prep.core;
using prep.movies;

namespace prep.sorting
{
  public static class SortingExtensions
  {
    public static IEnumerable<T> sort_using<T>(this IEnumerable<T> items,
      IComparer<T> comparison)
    {
      var sorted = new List<T>(items);
      sorted.Sort(comparison);
      return sorted;
    }

    public static IComparer<T> reverse<T>(this IComparer<T> to_reverse)
    {
      return new ReverseComparer<T>(to_reverse);
    }

    public static IComparer<T> then_by<T>(this IComparer<T> first, IComparer<T> second)
    {
      return new CombinedComparer<T>(first, second);
    }

    public static IComparer<ItemToCompare> then_by<ItemToCompare, AttributeType>(this IComparer<ItemToCompare> first,
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor)
      where AttributeType : IComparable<AttributeType>
    {
      return first.then_by(Compare<ItemToCompare>.by(attribute_accessor));
    }

    public static IComparer<ItemToCompare> then_by<ItemToCompare, AttributeType>(
      this IComparer<ItemToCompare> first,
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor,
      IApplyASortDirection direction)
      where AttributeType : IComparable<AttributeType>
    {
      return first.then_by(Compare<ItemToCompare>.by(attribute_accessor, direction));
    }

    public static IComparer<ItemToCompare> then_by<ItemToCompare, AttributeType>(
      this IComparer<ItemToCompare> first,
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor,
      params AttributeType[] values)
    {
      return first.then_by(Compare<ItemToCompare>.by(attribute_accessor, values));
    }
  }
}