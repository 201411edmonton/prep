namespace prep.matching
{
  public class NegatingMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    IMatchA<ItemToMatch> to_negate;

    public NegatingMatch(IMatchA<ItemToMatch> to_negate)
    {
      this.to_negate = to_negate;
    }

    public bool matches(ItemToMatch item)
    {
      return !to_negate.matches(item);
    }
  }
}