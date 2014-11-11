using prep.core;

namespace prep.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_match(IMatchA<AttributeType> value_matcher)
      {
        return original.create_match(value_matcher).not();
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> create_match(IMatchA<AttributeType> value_matcher)
    {
      return new AttributeValueMatch<ItemToMatch, AttributeType>(
        accessor,
        value_matcher);
    }
  }
}