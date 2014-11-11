namespace prep.matching
{
  public interface IMatchA<in ItemToMatch>
  {
    bool matches(ItemToMatch item);
  }
}