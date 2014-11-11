﻿using System.Collections.Generic;

namespace prep.matching
{
  public class EqualToAny<T> : IMatchA<T>
  {
    IList<T> values;

    public EqualToAny(params T[] values)
    {
      this.values = new List<T>(values);
    }

    public bool matches(T value)
    {
      return values.Contains(value);
    }
  }
}