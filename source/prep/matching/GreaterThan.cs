using System;

namespace prep.matching
{
  public class GreaterThan<T> : IMatchA<T> where T : IComparable<T>
  {
    T start;

    public GreaterThan(T start)
    {
      this.start = start;
    }

    public bool matches(T item)
    {
      return item.CompareTo(start) > 0;
    }
  }
}