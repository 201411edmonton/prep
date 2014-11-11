using System;
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

    public IMatchA<ItemToMatch> equal_to(AttributeType value)
    {
      return new ConditionalMatch<ItemToMatch>(x => accessor(x).Equals(value));
    }

    public IEnumerable<IMatchA<ItemToMatch>> equal_to_any(params AttributeType[] values)
    {
        var manyConditions = new List<IMatchA<ItemToMatch>>(){}; 
        foreach (AttributeType attrib in values)
        {
            manyConditions.Add(equal_to(attrib));
        }
        return manyConditions;
    }
  }
}