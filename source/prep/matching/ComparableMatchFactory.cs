using System;

namespace prep.matching
{
  public class ComparableMatchFactory<ItemToMatch, AttributeType> : ICreateMatchers<ItemToMatch, AttributeType> 
    where AttributeType : IComparable<AttributeType>

  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;
    ICreateMatchers<ItemToMatch, AttributeType> regular_match_factory;

    public ComparableMatchFactory(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor,
      ICreateMatchers<ItemToMatch, AttributeType> regular_match_factory)
    {
      this.accessor = accessor;
      this.regular_match_factory = regular_match_factory;
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
      return regular_match_factory.equal_to(values);
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return regular_match_factory.not_equal_to(value);
    }

    public IMatchA<ItemToMatch> blah(AttributeType value)
    {
      return regular_match_factory.blah(value);
    }
  }
}