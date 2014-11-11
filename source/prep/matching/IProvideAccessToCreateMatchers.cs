namespace prep.matching
{
  public interface IProvideAccessToCreateMatchers<in ItemToMatch, out AttributeType>
  {
    IMatchA<ItemToMatch> create_match(IMatchA<AttributeType> value_matcher);
  }
}