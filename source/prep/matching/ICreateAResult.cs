namespace prep.matching
{
  public interface ICreateAResult<in ItemToMatch, out AttributeType, out ResultType>
  {
    ResultType create_result(IMatchA<AttributeType> value_matcher);
  }
}