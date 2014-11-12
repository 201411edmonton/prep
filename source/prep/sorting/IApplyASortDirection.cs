using System.Collections.Generic;

namespace prep.sorting
{
  public interface IApplyASortDirection
  {
    IComparer<T> apply_to<T>(IComparer<T> comparer);
  }

  public class RegularSortDirection : IApplyASortDirection
  {
    public IComparer<T> apply_to<T>(IComparer<T> comparer)
    {
      return comparer;
    }
  }

  public class ReverseSortDirection : IApplyASortDirection
  {
    public IComparer<T> apply_to<T>(IComparer<T> comparer)
    {
      return comparer.reverse();
    }
  }
}