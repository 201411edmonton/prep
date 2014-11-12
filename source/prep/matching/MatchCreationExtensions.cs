using System;
using prep.core;
using prep.matching.core;
using prep.ranges;

namespace prep.matching
{
  public static class MatchCreationExtensions
  {
    public static ResultType equal_to<ItemToMatch, AttributeType, ResultType>(
      this ICreateAResult<ItemToMatch, AttributeType, ResultType> extension_point, params AttributeType[] values)
    {
      return create_from_value_matcher(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static ResultType greater_than<ItemToMatch, AttributeType, ResultType>(
      this ICreateAResult<ItemToMatch, AttributeType, ResultType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return create_from_value_matcher(extension_point, new GreaterThan<AttributeType>(value));
    }

    public static ResultType between<ItemToMatch, AttributeType, ResultType>(
      this ICreateAResult<ItemToMatch, AttributeType, ResultType> extension_point, AttributeType start,
      AttributeType end) where AttributeType : IComparable<AttributeType>
    {
      return create_from_value_matcher(extension_point, new IsBetween<AttributeType>(start, end));
    }

    public static ResultType falls_in<ItemToMatch, AttributeType, ResultType>(
      this ICreateAResult<ItemToMatch, AttributeType, ResultType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_from_value_matcher(extension_point, new FallsInRange<AttributeType>(range));
    }

    public static ResultType create_from_value_matcher<ItemToMatch, AttributeType, ResultType>(
      this ICreateAResult<ItemToMatch, AttributeType, ResultType> extension_point, IMatchA<AttributeType> value_matcher)
    {
      return extension_point.create_result(value_matcher);
    }
  }
}