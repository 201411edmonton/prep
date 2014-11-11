namespace prep.matching
{
  public static class MatchExtensions
  {
    public static IMatchA<ItemToMatch> or<ItemToMatch>(this IMatchA<ItemToMatch> left,
      IMatchA<ItemToMatch> right)
    {
      return new OrMatch<ItemToMatch>(left, right);
    }
  }
}