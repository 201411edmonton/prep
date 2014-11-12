using System;

namespace prep.ranges
{
  public interface IContainValues<in T> where T : IComparable<T>
  {
    bool contains(T value); 
  }
}