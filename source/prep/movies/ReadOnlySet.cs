using System.Collections;
using System.Collections.Generic;

namespace prep.movies
{
  public class ReadOnlySet<T> : IEnumerable<T>
  {
    IEnumerable<T> items;

    public ReadOnlySet(IEnumerable<T> items)
    {
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      foreach (var item in items)
        yield return item;
    }
  }
}