namespace prep.sorting
{
  public class SortDirection
  {
    public static readonly IApplyASortDirection ascending = new RegularSortDirection();
    public static readonly IApplyASortDirection descending = new ReverseSortDirection(); 
  }

}