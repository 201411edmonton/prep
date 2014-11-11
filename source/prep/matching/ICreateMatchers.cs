namespace prep.matching
{
  public interface ICreateMatchers<in ItemToMatch, in AttributeType>
  {
    IMatchA<ItemToMatch> equal_to(params AttributeType[] values);
    IMatchA<ItemToMatch> not_equal_to(AttributeType value);
    IMatchA<ItemToMatch> blah(AttributeType value);
  }
}