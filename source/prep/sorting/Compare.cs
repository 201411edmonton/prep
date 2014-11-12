using System;
using System.Collections.Generic;
using prep.core;

namespace prep.sorting
{
  public class Compare<ItemToCompare>
  {
    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor,
      IApplyASortDirection direction)
      where AttributeType : IComparable<AttributeType>
    {
      var comparer = new AttributeComparer<ItemToCompare, AttributeType>(attribute_accessor,
        new ComparableComparer<AttributeType>());

      return direction.apply_to(comparer);
    }

    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor)
      where AttributeType : IComparable<AttributeType>
    {
      return by(attribute_accessor, SortDirection.ascending);
    }

    public static IComparer<ItemToCompare> by<AttributeType>(
      IGetAnAttributeValue<ItemToCompare, AttributeType> attribute_accessor,
      params AttributeType[] values)
    {
      return new AttributeComparer<ItemToCompare, AttributeType>(
        attribute_accessor,
        new FixedComparer<AttributeType>(values));
    }
  }
}