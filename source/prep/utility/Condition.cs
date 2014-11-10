namespace prep.utility
{
  public delegate bool Condition<in ItemToCheck>(ItemToCheck item);
}