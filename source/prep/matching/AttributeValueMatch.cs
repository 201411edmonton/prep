using prep.core;
using prep.matching.core;

namespace prep.matching
{
  public class AttributeValueMatch<ItemToMatch, AttributeType> : IMatchA<ItemToMatch>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> get_the_value;
    IMatchA<AttributeType> value_criteria;

    public AttributeValueMatch(IGetAnAttributeValue<ItemToMatch, AttributeType> get_the_value,
      IMatchA<AttributeType> value_criteria)
    {
      this.get_the_value = get_the_value;
      this.value_criteria = value_criteria;
    }

    public bool matches(ItemToMatch item)
    {
      var value = get_the_value(item);
      return value_criteria.matches(value);
    }
  }
}