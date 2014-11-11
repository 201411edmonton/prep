namespace prep.matching
{
  public delegate AttributeType IGetAnAttributeValue<in ItemWithAttribute, out AttributeType>(ItemWithAttribute value);
}