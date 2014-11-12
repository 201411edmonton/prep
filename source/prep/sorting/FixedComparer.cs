using System.Collections.Generic;

namespace prep.sorting
{
  public class FixedComparer<AttributeType> : IComparer<AttributeType>
  {
    IList<AttributeType> values;

    public FixedComparer(IEnumerable<AttributeType> values)
    {
      this.values = new List<AttributeType>(values);
    }

    public int Compare(AttributeType x, AttributeType y)
    {
      return values.IndexOf(x).CompareTo(values.IndexOf(y));
    }
  }
}