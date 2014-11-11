using System.Collections.Generic;

namespace prep.matching
{
  public class MatchFactory<ItemToMatch, AttributeType>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public MatchFactory(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> equal_to(params AttributeType[] values)
    {
      return new ConditionalMatch<ItemToMatch>(x =>
      {
        var value = accessor(x);
        return new List<AttributeType>(values).Contains(value);
      });
    }

    public IMatchA<ItemToMatch> not_equal_to(AttributeType value)
    {
      return equal_to(value).not();
    }
  }
}