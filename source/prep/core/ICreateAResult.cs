using prep.matching.core;

namespace prep.core
{
  public interface ICreateAResult<in ItemWithAttribute, out AttributeType, out ResultType>
  {
    ResultType create_result(IMatchA<AttributeType> value_matcher);
  }
}