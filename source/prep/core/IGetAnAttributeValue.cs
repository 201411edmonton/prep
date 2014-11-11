namespace prep.core
{
  public delegate AttributeType IGetAnAttributeValue<in ItemWithAttribute, out AttributeType>(ItemWithAttribute value);
}