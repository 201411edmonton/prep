using prep.core;

namespace prep.matching
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> :
    ICreateAResult<ItemToMatch, AttributeType, IMatchA<ItemToMatch>>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public ICreateAResult<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> not
    {
      get { return new NegatingMatchCreationExtensionPoint(this); }
    }

    class NegatingMatchCreationExtensionPoint : ICreateAResult<ItemToMatch, AttributeType, IMatchA<ItemToMatch>>
    {
      ICreateAResult<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> original;

      public NegatingMatchCreationExtensionPoint(
        ICreateAResult<ItemToMatch, AttributeType, IMatchA<ItemToMatch>> original)
      {
        this.original = original;
      }

      public IMatchA<ItemToMatch> create_result(IMatchA<AttributeType> value_matcher)
      {
        return original.create_result(value_matcher).not();
      }
    }

    public MatchCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchA<ItemToMatch> create_result(IMatchA<AttributeType> value_matcher)
    {
      return new AttributeValueMatch<ItemToMatch, AttributeType>(
        accessor,
        value_matcher);
    }
  }
}