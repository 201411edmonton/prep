using System;

namespace prep.matching
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchA<ItemToMatch> greater_than<ItemToMatch>(
      this MatchCreationExtensionPoint<ItemToMatch, DateTime> extension_point, int year)
    {
      return extension_point.create_from_value_matcher(
        Match<DateTime>.with_attribute(x => x.Year).greater_than(year));
    }

  }
}