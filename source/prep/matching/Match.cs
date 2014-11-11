namespace prep.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchFactory<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      return new MatchFactory<ItemToMatch, AttributeType>(accessor);
    }
  }
}