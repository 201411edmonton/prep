using System;
using prep.core;

namespace prep.matching
{
  public static class MatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> equal_to<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_from_value_matcher(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static IMatchA<ItemToMatch> not_equal_to<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
    {
      return equal_to(extension_point, value).not();
    }

    public static IMatchA<ItemToMatch> greater_than<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return create_from_value_matcher(extension_point, new GreaterThan<AttributeType>(value));
    }

    public static IMatchA<ItemToMatch> between<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, AttributeType start,
      AttributeType end) where AttributeType : IComparable<AttributeType>
    {
      return create_from_value_matcher(extension_point, new IsBetween<AttributeType>(start, end));
    }

    public static IMatchA<ItemToMatch> create_from_condition<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, Condition<ItemToMatch> condition)
    {
      return new ConditionalMatch<ItemToMatch>(condition);
    }

    public static IMatchA<ItemToMatch> create_from_value_matcher<ItemToMatch, AttributeType>(
      this MatchCreationExtensionPoint<ItemToMatch, AttributeType> extension_point, IMatchA<AttributeType> value_matcher)
    {
      return new AttributeValueMatch<ItemToMatch, AttributeType>(extension_point.accessor,
        value_matcher);
    }
  }
}