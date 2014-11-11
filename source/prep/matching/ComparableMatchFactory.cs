using System;

namespace prep.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType>
    where AttributeType : IComparable<AttributeType>

  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public ComparableMatchFactory(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
    }
  }
}