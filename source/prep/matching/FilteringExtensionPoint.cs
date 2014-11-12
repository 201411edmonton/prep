using System.Collections.Generic;

namespace prep.matching
{
  public class FilteringExtensionPoint<ItemToFilter, AttributeType>
    : ICreateAResult<ItemToFilter, AttributeType, IEnumerable<ItemToFilter>>
  {
    IEnumerable<ItemToFilter> items;
    ICreateAResult<ItemToFilter, AttributeType, IMatchA<ItemToFilter>> match_extension_point;

    public ICreateAResult<ItemToFilter, AttributeType, IEnumerable<ItemToFilter>> not
    {
      get { return new NegatingFilteringExtensionPoint(this); }
    }

    public FilteringExtensionPoint(IEnumerable<ItemToFilter> items,
      ICreateAResult<ItemToFilter, AttributeType, IMatchA<ItemToFilter>> match_extension_point)
    {
      this.items = items;
      this.match_extension_point = match_extension_point;
    }

    public IEnumerable<ItemToFilter> create_result(IMatchA<AttributeType> value_matcher)
    {
      return items.all_items_matching(match_extension_point.create_result(value_matcher));
    }

    class NegatingFilteringExtensionPoint : ICreateAResult<ItemToFilter, AttributeType, IEnumerable<ItemToFilter>>
    {
      ICreateAResult<ItemToFilter, AttributeType, IEnumerable<ItemToFilter>> original;

      public NegatingFilteringExtensionPoint(
        ICreateAResult<ItemToFilter, AttributeType, IEnumerable<ItemToFilter>> original)
      {
        this.original = original;
      }

      public IEnumerable<ItemToFilter> create_result(IMatchA<AttributeType> value_matcher)
      {
        return original.create_result(value_matcher.not());
      }
    }
  }
}