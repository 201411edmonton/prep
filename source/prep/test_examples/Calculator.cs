using System;

namespace prep.test_examples
{
  public class Calculator
  {
    public int add(int first, int second)
    {
        if (first < 0 || second > 0)
        {
            return first + second;
        }
        else
        {
            throw new  ArgumentException();
        }
    }
  }
}