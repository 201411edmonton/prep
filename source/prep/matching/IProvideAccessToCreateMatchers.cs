namespace prep.matching
{
  public interface ICreateAMatcher<in ItemToMatch, out AttributeType>
  {
    IMatchA<ItemToMatch> create_match(IMatchA<AttributeType> value_matcher);
  }

  public interface IProvideAccessToCreateMatchers<in ItemToMatch, out AttributeType>
    : ICreateAMatcher<ItemToMatch, AttributeType>
  {
  }
}