using System;

namespace prep.matching
{
  public class MatchFactory<ItemToMatch, AttributeType>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public MatchFactory(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IMatchA<ItemToMatch> equal_to_any(params AttributeType[] values)
    {
      throw new NotImplementedException();
    }
  }
}