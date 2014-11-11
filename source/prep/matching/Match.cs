using System;

namespace prep.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      return new MatchFactory<ItemToMatch, AttributeType>(accessor);
    }

    public static ComparableMatchFactory<ItemToMatch, AttributeType> with_comparable_attribute<AttributeType>(
      IGetAnAttributeValue<ItemToMatch, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return new ComparableMatchFactory<ItemToMatch, AttributeType>(accessor, new MatchFactory<ItemToMatch,AttributeType>(accessor));
    }
  }
}