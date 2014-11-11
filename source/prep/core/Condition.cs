namespace prep.core
{
  public delegate bool Condition<in ItemToCheck>(ItemToCheck item);
}