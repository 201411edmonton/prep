using System.Collections.Generic;
using prep.core;

namespace prep.sorting
{
  public class AttributeComparer<ItemWithAttribute, AttributeType>
    : IComparer<ItemWithAttribute>
  {
    IGetAnAttributeValue<ItemWithAttribute, AttributeType> get_the_value;
    IComparer<AttributeType> value_comparison;

    public AttributeComparer(IGetAnAttributeValue<ItemWithAttribute, AttributeType> get_the_value, IComparer<AttributeType> value_comparison)
    {
      this.get_the_value = get_the_value;
      this.value_comparison = value_comparison;
    }

    public int Compare(ItemWithAttribute x, ItemWithAttribute y)
    {
      var first_value = get_the_value(x);
      var second_value = get_the_value(y);

      return value_comparison.Compare(first_value, second_value);
    }
  }
}