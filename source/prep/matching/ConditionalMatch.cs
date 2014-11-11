using prep.utility;

namespace prep.matching
{
  public class ConditionalMatch<ItemToMatch> : IMatchA<ItemToMatch>
  {
    Condition<ItemToMatch> condition;

    public ConditionalMatch(Condition<ItemToMatch> condition)
    {
      this.condition = condition;
    }

    public bool matches(ItemToMatch item)
    {
      return condition(item);
    }
  }
}