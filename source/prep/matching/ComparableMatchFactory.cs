using System;

namespace prep.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType>
    where AttributeType : IComparable<AttributeType>

  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;
      private MatchFactory<ItemToMatch, AttributeType> regularMatchFactory;
    public ComparableMatchFactory(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor, MatchFactory<ItemToMatch, AttributeType> regularMatchFactory)
    {
      this.accessor = accessor;
      this.regularMatchFactory = regularMatchFactory;
    }

    public IMatchA<ItemToMatch> greater_than(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchA<ItemToMatch> between(AttributeType start, AttributeType end)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
    }

    public IMatchA<ItemToMatch> equal_to(params AttributeType[] values)
    {
      return regularMatchFactory.equal_to(values);
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return regularMatchFactory.not_equal_to(value);
    }
  }
}