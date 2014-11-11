namespace prep.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType>
  {
    public IGetAnAttributeValue<ItemToMatch, AttributeType> accessor { get; private set; }

    public MatchCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }
  }
}