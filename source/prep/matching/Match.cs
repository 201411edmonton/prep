namespace prep.matching
{
  public class Match<ItemToMatch>
  {
    public static MatchCreationExtensionPoint<ItemToMatch, AttributeType> with_attribute<AttributeType>(
      IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      return new MatchCreationExtensionPoint<ItemToMatch, AttributeType>(accessor);
    }
  }
}