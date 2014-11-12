using System;
using System.Collections.Generic;

namespace prep.sorting
{
  public class ComparableComparer<AttributeType> : IComparer<AttributeType>
    where AttributeType : IComparable<AttributeType>
  {
    public int Compare(AttributeType x, AttributeType y)
    {
      return x.CompareTo(y);
    }
  }
}