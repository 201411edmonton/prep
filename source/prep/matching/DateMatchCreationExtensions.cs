using System;
using prep.core;

namespace prep.matching
{
  public static class DateMatchCreationExtensions
  {
    public static ResultType greater_than<ItemToMatch, ResultType>(
      this ICreateAResult<ItemToMatch, DateTime, ResultType> extension_point, int year)
    {
      return extension_point.create_from_value_matcher(
        Match<DateTime>.with_attribute(x => x.Year).greater_than(year));
    }
  }
}