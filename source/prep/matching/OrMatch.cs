namespace prep.matching
{
  public class OrMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    IMatchA<ItemToMatch> left;
    IMatchA<ItemToMatch> right;

    public OrMatch(IMatchA<ItemToMatch> left, IMatchA<ItemToMatch> right)
    {
      this.left = left;
      this.right = right;
    }

    public bool matches(ItemToMatch item)
    {
      return left.matches(item) || right.matches(item);
    }
  }
}