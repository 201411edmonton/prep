using System;
using prep.core;
using prep.matching.core;

namespace prep.matching
{
  public static class MatchExtensions
  {
    public static IMatchA<ItemToMatch> or<ItemToMatch>(this IMatchA<ItemToMatch> left,
      IMatchA<ItemToMatch> right)
    {
      return new OrMatch<ItemToMatch>(left, right);
    }

    public static IMatchA<ItemToMatch> not<ItemToMatch>(this IMatchA<ItemToMatch> to_negate)
    {
      return new NegatingMatch<ItemToMatch>(to_negate);
    }

    public static ResultType or<ItemToMatch, AttributeType, ResultType>(this ResultType result,
      Func<ICreateAResult<ItemToMatch, AttributeType, ResultType>, ResultType> next)
    {
      throw new NotImplementedException();
    }
  }
}