namespace prep.matching.core
{
  public interface IMatchA<in ItemToMatch>
  {
    bool matches(ItemToMatch item);
  }
}